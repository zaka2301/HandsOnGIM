using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallboi_behaviour : enemy_behaviour
{
    [SerializeField] GameObject Bullet;
    public float move_speed;
    public int wave;
    public float shoot_chance;

    private float timer;

    public float shoot_interval;
    public Vector2 end_pos;
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(start_pos, end_pos, Mathf.SmoothStep(0.0f, 1.0f, lifetime * move_speed));
    }
}
