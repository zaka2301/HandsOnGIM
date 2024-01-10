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
    // Start is called before the first frame update
    void Start()
    {
                    SpawnTrashWave(2, 5.0f, 3, (int) Mathf.Sign(Random.Range(-5,5)));

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
            SpawnTrashWave(2, Random.Range(2,5), 3, (int) Mathf.Sign(Random.Range(-5,5)));
            
            timer -= spawninterval;
        }
        
    }
    void spawn()
    {
        //float maxP = transform.position.x + Xoffset;
        //float minP = transform.position.x - Xoffset;
        //Instantiate(Object, new Vector3(Random.Range(minP, maxP), transform.position.y, 0), transform.rotation);
    }



    void SpawnTrashWave(int wave, float speed, int amount, int mirror)
    {
        float distance = 0.2f; //distance between each enemy
        float delay = 0.3f;
        switch(wave)
        {
            case 1:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               9,
                                               distance,
                                               wave,
                                               mirror,
                                               speed,
                                               1.0f,
                                               -1.0f
                                               ));
                break;
            case 2:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               5,
                                               distance,
                                               wave,
                                               mirror,
                                               speed,
                                               1.0f,
                                               -2.0f
                                               ));
                break;
            case 3:
                StartCoroutine(SpawnTrashUnits(delay,
                                               amount,
                                               -5,
                                               9,
                                               distance,
                                               wave,
                                               mirror,
                                               speed,
                                               1.0f,
                                               -2.0f
                                               ));
                break;
            default:
                break;
        }

        
    }

    IEnumerator SpawnTrashUnits(float delay, int amount, float pos_x, float pos_y, float distance, int wave, int mirror, float speed, float move_x, float move_y)
    {
        for (int i = 0; i < amount; ++i){
            SpawnTrashUnit(pos_x, pos_y, distance, wave, mirror, speed, move_x, move_y);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnTrashUnit(float pos_x, float pos_y, float distance, int wave, int mirror, float speed, float move_x, float move_y)
    {
        GameObject trash = Instantiate(Trash, new Vector3(pos_x* mirror, pos_y, 0), transform.rotation) as GameObject;
        trash_movement trash_property = trash.GetComponent<trash_movement>();

        trash_property.wave = wave;
        trash_property.move_speed = speed;
        trash_property.move_x = move_x * mirror;
        trash_property.move_y = move_y;

    }

}
