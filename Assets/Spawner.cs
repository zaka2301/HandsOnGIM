using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Trash;
    [SerializeField] GameObject Bitch;
    [SerializeField] GameObject Smallboi;
    [SerializeField] GameObject Bigboi;

    [SerializeField] GameObject Spider;
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
        SpawnSpider();
        //SpawnWave(Bigboi, 3, Random.Range(1,3), (int)  Mathf.Sign(Random.Range(-5,5)), 10,  Random.Range(0.25f,1.0f), 3.0f, 1);
    }


    void Update()
    {
        if (timer < spawninterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            int p = 0;//Random.Range(0,10);

            switch(p)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    SpawnWave(Trash, 3, 1, (int)  Mathf.Sign(Random.Range(-5,5)), 1,  Random.Range(0.25f,1.0f), 1.0f, 1);
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    SpawnWave(Bitch, 3, Random.Range(1,3), (int)  Mathf.Sign(Random.Range(-5,5)), 1,  Random.Range(0.25f,1.0f), 1.0f, 0.5f);
                    break;
                case 8:
                    SpawnWave(Smallboi, 3, Random.Range(1,3), (int)  Mathf.Sign(Random.Range(-5,5)), 3,  Random.Range(0.25f,1.0f), 2.0f, 1);
                    break;
                case 9:
                    SpawnWave(Bigboi, 3, Random.Range(1,3), (int)  Mathf.Sign(Random.Range(-5,5)), 5,  Random.Range(0.25f,1.0f), 3.0f, 1);
                    break;
                case 10:
                default:
                    break;


   
            }


            timer -= spawninterval;
        }
        
    }

    private void SpawnSpider()
    {
        SpawnUnit(Spider, 0, 10, 0, 10, 0, 0, 50, 1, 5.0f, 1.0f);
    }

    private void SpawnWave(GameObject enemy, int amount, int wave, int mirror, int health, float speed, float interval, float chance)
    {

        switch(enemy.name)
        {
            case "Trash":
                StartCoroutine(SpawnUnits(enemy,
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
                break;
            case "Bitch":
                if(wave==1)
                {
                        StartCoroutine(SpawnUnits(enemy,
                                                  3,
                                                  -5,
                                                  9,
                                                  5,
                                                  0,
                                                  wave,
                                                  mirror,
                                                  health,
                                                  speed,
                                                  interval,
                                                  chance
                                                  ));

                }
                else
                {
                        float distance = 1.5f;
                        float bx0 = 0 - (amount-1) * distance * 0.5f;
                        float by0 = 9.0f;
                        for (int i = 0; i < amount; ++i)
                        {

                            SpawnUnit(enemy,
                                      bx0 + i * distance,
                                      by0,
                                      bx0 + i * distance,
                                      -9,
                                      wave,
                                      1,
                                      health,
                                      speed,
                                      interval,
                                      chance
                            );
                        }


                }
                break;
            case "Smallboi":

                for (int i = 0; i < (wave+2); ++i)
                {
                    float sx0 = smallboi_waveLUT[wave-1, i];
                    float sy1 = smallboi_waveLUT[wave-1, i+4];
                    SpawnUnit(enemy,
                              sx0,
                              sy1+9+i*2,
                              sx0,
                              sy1,
                              wave,
                              mirror,
                              health,
                              speed,
                              interval
                    );       
                }
                break;
            case "Bigboi":
                float Bx0 = -2.5f*(wave-1);
                float By1 =  5*(wave-1);
                for (int i = 0; i < wave; ++i)
                {
                    SpawnUnit(enemy,
                              Bx0 + i*5,
                              9,
                              Bx0 + i*5,
                              By1,
                              wave,
                              mirror,
                              health,
                              speed,
                              interval
                    );       
                }
                break;
            default:
                break;
            
        }      

    }


    IEnumerator SpawnUnits(GameObject enemy, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, int health, float speed, float interval = 0, float chance = 0)
    {
        for (int i = 0; i < amount; ++i){
            SpawnUnit(enemy, x0, y0, x1, y1, wave, mirror, health, speed, interval, chance);
            yield return new WaitForSeconds(gap/speed);
        }
    }



    private void SpawnUnit(GameObject enemy, float x0, float y0, float x1, float y1, int wave, int mirror, int health, float speed, float interval = 0, float chance = 0)
    {
        Vector3 p0 = new Vector3(x0* mirror, y0, 0);
        GameObject enemy_to_spawn = Instantiate(enemy, p0, transform.rotation) as GameObject;
        enemy_behaviour enemy_property = enemy_to_spawn.GetComponent<enemy_behaviour>();

        enemy_property.SetHealth(health);
        enemy_property.wave = wave;
        enemy_property.move_speed = speed;
        enemy_property.shoot_chance = chance;
        enemy_property.shoot_interval = interval;
        enemy_property.start_pos = p0;
        enemy_property.end_pos = new Vector2(x1 * mirror, y1);
    }

}
