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
    [SerializeField] float delay = 0.2f;
    private float timer;

    //                                             x0 y0 x1 y1
    private float[,] trash_waveLUT = new float[,]{{-5, 9, 5,  0}, //wave 1
                                                  {-5, 5, 5,  0}, //wave 2
                                                  {-5, 9, 5, -9}  //wave 3
    };
      
    void Update()
    {
        if (timer < spawninterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if(Random.Range(0.0f, 1.0f) < 0.5f)
            {
                SpawnBitchWave(Random.Range(1,3), Random.Range(0.5f,2.0f), Random.Range(1,5),(int)  Mathf.Sign(Random.Range(-5,5)), 1, 0.1f);
            }
            else
            {
                SpawnTrashWave(Random.Range(1,3), Random.Range(0.5f,2.0f), Random.Range(1,5),(int)  Mathf.Sign(Random.Range(-5,5)), 1);
            }
            timer -= spawninterval;
        }
        
    }

    void SpawnBitchWave(int wave, float speed, int amount, int mirror, int health, float shoot_chance)
    {

        switch(wave)
        {
            case 1:
                StartCoroutine(SpawnBitchUnits(delay/speed,
                                               3,
                                               -5,
                                               9,
                                               5,
                                               0,
                                               wave,
                                               mirror,
                                               health,
                                               speed,
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
                                   shoot_chance
                    );
                }
                break;
        
        }
    }
    IEnumerator SpawnBitchUnits(float delay, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, int health, float speed, float chance)
    {
        for (int i = 0; i < amount; ++i){
            SpawnBitchUnit(x0, y0, x1, y1, wave, mirror, health, speed, chance);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnBitchUnit(float x0, float y0, float x1, float y1, int wave, int mirror, int health, float speed, float chance)
    {
        GameObject bitch = Instantiate(Bitch, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        bitch_behaviour bitch_property = bitch.GetComponent<bitch_behaviour>();

        bitch_property.SetHealth(health);
        bitch_property.wave = wave;
        bitch_property.move_speed = speed;
        bitch_property.end_pos = new Vector3(x1 * mirror, y1);
        bitch_property.mid_pos = new Vector3(-4 * mirror, 0);
        bitch_property.shoot_chance = chance;

    }

    
    void SpawnTrashWave(int wave, float speed, int amount, int mirror, int health)
    {
        StartCoroutine(SpawnTrashUnits(delay/speed,
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

    IEnumerator SpawnTrashUnits(float delay, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, int health, float speed)
    {
        for (int i = 0; i < amount; ++i){
            SpawnTrashUnit(x0, y0, x1, y1, wave, mirror, health, speed);
            yield return new WaitForSeconds(delay);
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
