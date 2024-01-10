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
        //spawn();
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
            spawn_trash(1, 5.0f, 3, (int) Mathf.Sign(Random.Range(-5,5)));
            
            timer -= spawninterval;
        }
        
    }
    void spawn()
    {
        //float maxP = transform.position.x + Xoffset;
        //float minP = transform.position.x - Xoffset;
        //Instantiate(Object, new Vector3(Random.Range(minP, maxP), transform.position.y, 0), transform.rotation);
    }

    void spawn_trash(int wave, float speed, int amount, int mirror)
    {
        float distance = 0.2f; //distance between each enemy
        //Debug.Log(mirror);
        switch(wave)
        {
            case 1:
                for (int i = 0; i < amount; ++i)
                    {
                    GameObject trash = Instantiate(Trash, new Vector3(-5* mirror, 9, 0)*(i * distance + 1) , transform.rotation) as GameObject;
                    trash.GetComponent<trash_movement>().move_speed = speed;
                    trash.GetComponent<trash_movement>().move_x = 1.0f * mirror;
                    trash.GetComponent<trash_movement>().move_y = -2.0f;
                    }
                break;
            default:
                break;
        }

        
    }

}
