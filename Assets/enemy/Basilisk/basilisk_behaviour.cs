using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basilisk_behaviour : enemy_behaviour
{
    [SerializeField] int max_health;
    [SerializeField] Transform head;
    [SerializeField] Transform body;
    [SerializeField] float cannon_pos;
    [SerializeField] GameObject lunge_bullet;
    [SerializeField] float lunge_bullet_speed;
    [SerializeField] float lunge_shoot_interval;
    [SerializeField] float stack_interval;
    [SerializeField] GameObject oscilate_bullet;
    [SerializeField] GameObject rain_bullet;
    [SerializeField] float oscilate_shoot_interval;
    bool IsLunging;
    bool IsOscilate;
    float timer = 0f;


    void Start()
    {
        SetHealth(max_health);
    }

    void Update()
    {
        if (IsLunging == true) 
        {
            if (timer < lunge_shoot_interval)
            {
                timer += Time.deltaTime;
            }
            else
            {
                for(int i = -1; i < 6; i++)
                {
                    Shoot(lunge_bullet, new Vector2(2.6f, body.position.y+cannon_pos+i*stack_interval), new Vector2(4.6f, body.position.y+cannon_pos+i*stack_interval+1), lunge_bullet_speed);
                    Shoot(lunge_bullet, new Vector2(-2.6f, body.position.y+cannon_pos+i*stack_interval), new Vector2(-4.6f, body.position.y+cannon_pos+i*stack_interval+1), lunge_bullet_speed);
                }
                timer = 0f;
            }
        }
        else if (IsOscilate == true)
        {
            if (timer < oscilate_shoot_interval)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Instantiate(oscilate_bullet, head.position, body.rotation);
                GameObject oscilate = Instantiate(oscilate_bullet, head.position, body.rotation) as GameObject;
                oscilate.GetComponentInChildren<oscilate_bullet>().amplitude *= -1;
                Instantiate(rain_bullet, body.position, body.rotation);
                timer = 0f;
            }
        }
    }

    public void StartShoot()
    {
        timer = 0f;
        IsLunging = true;
    }

    public void EndShoot()
    {
        IsLunging = false;
    }

    public void StartOscilate()
    {
        timer = 0f;
        IsOscilate = true;
    }

    public void EndOscilate()
    {
        IsOscilate = false;
    }
}
