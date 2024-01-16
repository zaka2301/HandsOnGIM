using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float ROF;
    [HideInInspector]
    public float def_rof;
    private float timer;

    void Start()
    {
        def_rof = ROF;
        spawn();
    }
    void Update()
    {
        if (timer < ROF)
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
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
