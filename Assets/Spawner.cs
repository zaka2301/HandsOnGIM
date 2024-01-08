using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] float spawninterval;
    [SerializeField] float Xoffset;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawninterval)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawn();
            timer = 0;
        }
        
    }
    void spawn()
    {
        float maxP = transform.position.x + Xoffset;
        float minP = transform.position.x - Xoffset;
        Instantiate(Object, new Vector3(Random.Range(minP, maxP), transform.position.y, 0), transform.rotation);
    }
}
