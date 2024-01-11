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
    [SerializeField] float Xoffset;
    private float timer;

    private float delay = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnTrashWave(Random.Range(1, 4), 5, 3, (int) Mathf.Sign(Random.Range(-5,5)));
        SpawnBitchWave(Random.Range(1,3), 0.7f, Random.Range(1,5), (int) Mathf.Sign(Random.Range(-5,5)));
        //SpawnTrashWave(4, 1, 3, System.Math.Sign(Random.Range(-5,5)));
        //SpawnTrashWave(2, 1, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawninterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //SpawnTrashWave(Random.Range(1, 4), 5, 3, (int) Mathf.Sign(Random.Range(-5,5)));
            SpawnBitchWave(Random.Range(1,3), 0.7f, Random.Range(1,5),(int)  Mathf.Sign(Random.Range(-5,5)));
            //SpawnBitchWave(Random.Range(1,3), 0.7f, Random.Range(1,5), (int) Mathf.Sign(Random.Range(-5,5)));

            //SpawnTrashWave(4, 1, 3, (int) Mathf.Sign(Random.Range(-5,5)));
            
            timer -= spawninterval;
        }
        
    }

    void SpawnBitchWave(int wave, float speed, int amount, int mirror)
    {
        switch(wave)
        {
            case 1:
                StartCoroutine(SpawnBitchUnits(delay,
                                               3,
                                               -5,
                                               9,
                                               5,
                                               0,
                                               wave,
                                               mirror,
                                               speed
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
                                   speed
                    );
                }
                break;
        
        }
    }
    IEnumerator SpawnBitchUnits(float delay, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, float speed)
    {
        for (int i = 0; i < amount; ++i){
            SpawnBitchUnit(x0, y0, x1, y1, wave, mirror, speed);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnBitchUnit(float x0, float y0, float x1, float y1, int wave, int mirror, float speed)
    {
        GameObject bitch = Instantiate(Bitch, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        bitch_behaviour bitch_property = bitch.GetComponent<bitch_behaviour>();

        bitch_property.wave = wave;
        bitch_property.move_speed = speed;
        bitch_property.end_pos = new Vector3(x1 * mirror, y1);
        bitch_property.mid_pos = new Vector3(-4 * mirror, 0);

    }
    void SpawnTrashWave(int wave, float speed, int amount, int mirror)
    {
        
        switch(wave)
        {
            case 1:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               9,
                                               5,
                                               0,
                                               wave,
                                               mirror,
                                               speed
                                               ));
                break;
            case 2:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               5,
                                               5,
                                               0,
                                               wave,
                                               mirror,
                                               speed
                                               ));
                break;
            case 3:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               9,
                                               5,
                                               -9,
                                               wave,
                                               mirror,
                                               speed
                                               ));
                break;
            case 4:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               9,
                                               5,
                                               -9,
                                               wave,
                                               mirror,
                                               speed
                                               ));
                break;
            default:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               9,
                                               5,
                                               -9,
                                               wave,
                                               mirror,
                                               speed
                                               ));
                break;
        }

        
    }

    IEnumerator SpawnTrashUnits(float delay, int amount, float x0, float y0, float x1, float y1,  int wave, int mirror, float speed)
    {
        for (int i = 0; i < amount; ++i){
            SpawnTrashUnit(x0, y0, x1, y1, wave, mirror, speed);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnTrashUnit(float x0, float y0, float x1, float y1, int wave, int mirror, float speed)
    {
        GameObject trash = Instantiate(Trash, new Vector3(x0* mirror, y0, 0), transform.rotation) as GameObject;
        trash_behaviour trash_property = trash.GetComponent<trash_behaviour>();

        trash_property.wave = wave;
        trash_property.move_speed = speed;
        trash_property.end_pos = new Vector3(x1 * mirror, y1);
        trash_property.mid_pos = new Vector3(-3 * mirror, 0);

    }

}
