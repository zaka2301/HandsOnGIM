using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Trash;
    [SerializeField] int TrashHealth = 1;
    [SerializeField] float TrashSpeed = 0.9f;

    [SerializeField] GameObject Bitch;
    [SerializeField] int BitchHealth = 1;
    [SerializeField] float BitchSpeed = 0.75f;
    [SerializeField] float BitchShootInterval = 0.5f;
    [SerializeField] float BitchShootChance= 0.5f;

    [SerializeField] GameObject Smallboi;
    [SerializeField] int SmallboiHealth = 3;
    [SerializeField] float SmallboiSpeed = 0.7f;
    [SerializeField] float SmallboiShootInterval = 1.5f;

    [SerializeField] GameObject Bigboi;    
    [SerializeField] int BigboiHealth = 7;
    [SerializeField] float BigboiSpeed = 0.7f;
    [SerializeField] float BigboiShootInterval = 2.0f;

    [SerializeField] GameObject Spider;
    [SerializeField] float spawninterval;
    [SerializeField] float gap = 0.2f; //distance between each units
    private float timer;

    private List<GameObject> SpawnableEnemies = new List<GameObject>();
    private GameObject EnemyToSpawn;
    private int EnemiesAlive;
    private int waves = 1;
    private int BigboiWave;

    // Lookup table for trash wave positions
    //                                             x0 y0 x1 y1
    private float[,] trash_waveLUT = new float[,]{{-5, 9, 5,  0}, //wave 1
                                                  {-5, 5, 5,  0}, //wave 2
                                                  {-5, 9, 2.5f, -4.5f}  //wave 3
    };

    // Lookup table for smallboi wave positions
    //                                                  x0  x1   x2  x3,y0,y1,y2,y3
    private float[,] smallboi_waveLUT = new float[,]{{-2.5f,  0, 2.5f,  0, 7, 6, 7, 0}, //wave 1
                                                     {  -3, -1,   1,  3, 7, 5.5f, 4, 2.5f}, //wave 2
    };

    void Start()
    {
        SpawnWaves();
    }


    private void SpawnWaves()
    {
        if (waves == 5)
        {
            SpawnSpider();
        }

        {
            for (int i = 0; i < 4; ++i)
            {
                float chance = Random.Range(0.0f, 1.0f);

                if (chance < 0.143f)
                {
                    SpawnableEnemies.Add(Trash);
                }
                else if (chance < 0.286f)
                {
                    BigboiWave = Random50();
                    SpawnableEnemies.Add(Bigboi);
                }
                else if (chance < 0.571f)
                {
                    SpawnableEnemies.Add(Smallboi);
                }
                else
                {
                    SpawnableEnemies.Add(Bitch);
                }
            }
        }
        
    }  


    void Update()
    {
        if (timer < spawninterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            EnemiesAlive = SpawnableEnemies.Count;
            if(EnemiesAlive > 0)
            {
                for (int i = 0; i < EnemiesAlive; ++i)
                {
                    EnemyToSpawn = SpawnableEnemies[i];
                    if (EnemyToSpawn.name == "Smallboi" && GameObject.Find("Smallboi(Clone)") != null)
                    {
                    }
                    else
                    {
                        SpawnWave(EnemyToSpawn, 3);
                        SpawnableEnemies.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                waves += 1;
                SpawnWaves();
                }
            }
            timer -= spawninterval;
            //Debug.Log("Wave : " + waves);
        }
        
    }

    private void SpawnSpider()
    {
        SpawnUnit(Spider, 0, 20, 0, 10, 0, 0, 50, 1, 5.0f, 1.0f);
    }

    private int Random50()
    {
        float r = Random.Range(0.0f, 1.0f);

        return r < 0.5f ? 1 : 2;
    }
    private int Random33()
    {
        float r = Random.Range(0.0f, 1.0f);

        return r < 0.67f ? (r < 0.33f ? 1 : 2) : 3;
    }

    private int NextBigboiWave()
    {
        //prevent bigboi overlapping
        int t = BigboiWave;
        BigboiWave = (BigboiWave+1)%2;
        return t;
    }

    private void SpawnWave(GameObject enemy, int amount)
    {
        int mirror = (int) Mathf.Sign(Random.Range(-1.0f, 1.0f));
        int wave = Random50();

        switch(enemy.name)
        {
            case "Trash":
                wave = Random33();
                StartCoroutine(SpawnUnits(enemy,
                                          amount,
                                          trash_waveLUT[wave-1, 0],
                                          trash_waveLUT[wave-1, 1],
                                          trash_waveLUT[wave-1, 2],
                                          trash_waveLUT[wave-1, 3],
                                          wave,
                                          mirror,
                                          TrashHealth,
                                          TrashSpeed
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
                                                  BitchHealth,
                                                  BitchSpeed,
                                                  BitchShootInterval,
                                                  BitchShootChance
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
                                      -4,
                                      wave,
                                      1,
                                      BitchHealth,
                                      BitchSpeed,
                                      BitchShootInterval,
                                      BitchShootChance
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
                              SmallboiHealth,
                              SmallboiSpeed,
                              SmallboiShootInterval
                    );       
                }
                break;
            case "Bigboi":
                wave = NextBigboiWave();
                float Bx0 = -2.5f*(wave-1);
                float By1 =  5*(wave-1);
                for (int i = 0; i < wave; ++i)
                {
                    SpawnUnit(enemy,
                              Bx0 + i*5,
                              10,
                              Bx0 + i*5,
                              By1,
                              wave,
                              1,
                              BigboiHealth,
                              BigboiSpeed,
                              BigboiShootInterval
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
