using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Trash;
    [SerializeField] GameObject Bitch;
    [SerializeField] GameObject Smallboi;
    [SerializeField] GameObject Bigboi;
    [SerializeField] float spawninterval;
    [SerializeField] float gap = 0.2f; //distance between each units
    private float timer;

    // Lookup table for trash wave positions
    //                                             x0 y0 x1 y1
    private float[,] trash_waveLUT = new float[,]{{-5, 9, 5,  0}, //wave 1
                                                  {-5, 5, 5,  0}, //wave 2
                                                  {-5, 9, 5, -9}  //wave 3
    };

    // Lookup table for smallboi wave positions
    //                                                  x0  x1   x2  x3,y0,y1,y2,y3
    private float[,] smallboi_waveLUT = new float[,]{{-2.5f,  0, 2.5f,  0, 7, 6, 7, 0}, //wave 1
                                                     {  -3, -1,   1,  3, 7, 5.5f, 4, 2.5f}, //wave 2
    };

    void Start()
    {
        SpawnBigboiWave(2, Random.Range(0.25f,1.0f),(int)  Mathf.Sign(Random.Range(-5,5)), 10, 1.0f);
    }
      
    void Update()
    {
        if (timer < spawninterval)
        {
            timer += Time.deltaTime;
        }
        else
        {

            //====================
            //RANDOMLY SPAWN SHIT
            if(Random.Range(0.0f, 1.0f) < 1.5f)
            {
                //SpawnBitchWave(1, Random.Range(0.25f,1.0f), 3,(int)  Mathf.Sign(Random.Range(-5,5)), 1, 1.0f, 1.0f);
                //SpawnSmallboiWave(Random.Range(0.0f, 1.0f) < 0.5f ? 1 : 2, Random.Range(0.25f,1.0f),(int)  Mathf.Sign(Random.Range(-5,5)), 2, 0.5f);
            }
            else
            {
                //SpawnTrashWave(Random.Range(1,3), Random.Range(0.25f,1.0f), Random.Range(1,5),(int)  Mathf.Sign(Random.Range(-5,5)), 1);
            }
            //=====================


            timer -= spawninterval;
        }
        
    }
    void SpawnTrashWave(int wave, float speed, int amount, int mirror, int health)
    {
        StartCoroutine(SpawnTrashUnits(gap/speed,
                                       amount,
                                       trash_waveLUT[wave-1, 0],
                                       trash_waveLUT[wave-1, 1],
                                       trash_waveLUT[wave-1, 2],
                                       trash_waveLUT[wave-1, 3],
                                       wave,
                                       mirror,
                                       health,
                                       speed
                                       ));  
    }

    void SpawnBitchWave(int wave, float speed, int amount, int mirror, int health, float shoot_interval, float shoot_chance)
    {

        switch(wave)
        {
            case 1:
                StartCoroutine(SpawnBitchUnits(gap/speed,
                                               3,
                                               -5,
                                               9,
                                               5,
                                               0,
                                               wave,
                                               mirror,
                                               health,
                                               speed,
                                               shoot_interval,
                                               shoot_chance
                                               ));
                break;
            case 2:
            default:
                float distance = 1.5f;
                float x0 = 0 - (amount-1) * distance * 0.5f;
                float y0 = 9.0f;
                for (int i = 0; i < amount; ++i)
                {
                    
                    SpawnBitchUnit(x0 + i * distance,
                                   y0,
                                   x0 + i * distance,
                                   -9,
                                   wave,
                                   1,
                                   health,
                                   speed,
                                   shoot_interval,
                                   shoot_chance
                    );
                }
                break;
        
        }
    }

void SpawnSmallboiWave(int wave, float speed, int mirror, int health, float shoot_interval)
    {

                for (int i = 0; i < (wave+2); ++i)
                {
                    float x0 = smallboi_waveLUT[wave-1, i];
                    float y1 = smallboi_waveLUT[wave-1, i+4];
                    SpawnSmallboiUnit(x0,
                                      y1+9+i*2,
                                      x0,
                                      y1,
                                      wave,
                                      mirror,
                                      health,
                                      speed,
                                      shoot_interval
                    );       
                }
    }
void SpawnBigboiWave(int wave, float speed, int mirror, int health, float shoot_interval)
    {
        float x0 = -2.5f*(wave-1);
        float y1 =  5*(wave-1);
                for (int i = 0; i < wave; ++i)
                {
                    SpawnBigboiUnit(x0 + i*5,
                                    9,
                                    x0 + i*5,
                                    y1,
                                    wave,
                                    mirror,
                                    health,
                                    speed,
                                    shoot_interval
                    );       
                }
    }
void SpawnBigboiUnit(float x0, float y0, float x1, float y1, int wave, int mirror, int health, float speed, float interval)
    {
        GameObject bigboi = Instantiate(Bigboi, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        bigboi_behaviour bigboi_property = bigboi.GetComponent<bigboi_behaviour>();

        bigboi_property.SetHealth(health);
        bigboi_property.wave = wave;
        bigboi_property.move_speed = speed;
        bigboi_property.end_pos = new Vector3(x1 * mirror, y1);
        bigboi_property.shoot_interval = interval;
    }
    void SpawnSmallboiUnit(float x0, float y0, float x1, float y1, int wave, int mirror, int health, float speed, float interval)
    {
        GameObject smallboi = Instantiate(Smallboi, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        smallboi_behaviour smallboi_property = smallboi.GetComponent<smallboi_behaviour>();

        smallboi_property.SetHealth(health);
        smallboi_property.wave = wave;
        smallboi_property.move_speed = speed;
        smallboi_property.end_pos = new Vector3(x1 * mirror, y1);
        smallboi_property.shoot_interval = interval;

    }
    IEnumerator SpawnBitchUnits(float gap, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, int health, float speed, float interval, float chance)
    {
        for (int i = 0; i < amount; ++i){
            SpawnBitchUnit(x0, y0, x1, y1, wave, mirror, health, speed, interval, chance);
            yield return new WaitForSeconds(gap);
        }
    }

    void SpawnBitchUnit(float x0, float y0, float x1, float y1, int wave, int mirror, int health, float speed, float interval, float chance)
    {
        GameObject bitch = Instantiate(Bitch, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        bitch_behaviour bitch_property = bitch.GetComponent<bitch_behaviour>();

        bitch_property.SetHealth(health);
        bitch_property.wave = wave;
        bitch_property.move_speed = speed;
        bitch_property.end_pos = new Vector3(x1 * mirror, y1);
        bitch_property.mid_pos = new Vector3(-4 * mirror, 0);
        bitch_property.shoot_chance = chance;
        bitch_property.shoot_interval = interval;

    }

    IEnumerator SpawnTrashUnits(float gap, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, int health, float speed)
    {
        for (int i = 0; i < amount; ++i){
            SpawnTrashUnit(x0, y0, x1, y1, wave, mirror, health, speed);
            yield return new WaitForSeconds(gap);
        }
    }

    void SpawnTrashUnit(float x0, float y0, float x1, float y1, int wave, int mirror, int health, float speed)
    {
        GameObject trash = Instantiate(Trash, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        trash_behaviour trash_property = trash.GetComponent<trash_behaviour>();

        trash_property.SetHealth(health);
        trash_property.wave = wave;
        trash_property.move_speed = speed;
        trash_property.end_pos = new Vector3(x1 * mirror, y1);
        trash_property.mid_pos = new Vector3(-3 * mirror, 0);

    }

}
