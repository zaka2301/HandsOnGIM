using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float ROF;
    private BulletModToggle toggle;
    [HideInInspector]
    public float def_rof;
    private float timer;
    private large_shot large;
    private Enemy_tracking tracking;
    private charge_shot charge;

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
        large = bullet.GetComponent<large_shot>();
        tracking = bullet.GetComponent<Enemy_tracking>();
        charge = bullet.GetComponent<charge_shot>();

        large.enabled = BulletModToggle.LargeToggle;
        tracking.enabled = BulletModToggle.TrackingToggle;
        charge.enabled = BulletModToggle.ChargeToggle;

    }
}
