using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basilisk_body_behaviour : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float bulletSpeed;
    bool IsShooting;
    Transform body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShooting == true) 
        {
            // Shoot(bullet, body.position, new Vector2(body.position.x+1, body.position.y+1), bulletSpeed);
            // Shoot(bullet, body.position, new Vector2(body.position.x-1, body.position.y-1), bulletSpeed);
        }
    }

    public void StartShoot()
    {
        IsShooting = true;
    }

    public void EndShoot()
    {
        IsShooting = false;
    }
}
