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
        SpawnTrashWave(Random.Range(1, 3), Random.Range(1.0f, 1.0f), 3, (int) Mathf.Sign(Random.Range(-5,5)));
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
            SpawnTrashWave(Random.Range(1, 4), Random.Range(1.0f, 1.0f), 3, (int) Mathf.Sign(Random.Range(-5,5)));

            
            timer -= spawninterval;
        }
        
    }

    void SpawnTrashWave(int wave, float speed, int amount, int mirror)
    {
        float delay = 0.3f;
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
                                               speed/1.5f
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
                                               speed/1.5f
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
        trash_movement trash_property = trash.GetComponent<trash_movement>();

        trash_property.wave = wave;
        trash_property.move_speed = speed;
        trash_property.end_pos = new Vector3(x1 * mirror, y1, 0);
        trash_property.mid_pos = new Vector3(-3 * mirror, 0, 0);

    }

}
