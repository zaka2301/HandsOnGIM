using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_tracking : bullet_behaviour
{
    private Transform target;
    public Transform head;
    public float tracking_range;
    public string enemy_tag = "Enemy";
    public float tracking_strength;

    void Start()
    {
        InvokeRepeating("target_search", 0f, 0.2f);
    }

    void target_search()
    {
        GameObject[] enemy_inframe = GameObject.FindGameObjectsWithTag(enemy_tag);
        float nearest_distance = Mathf.Infinity;
        GameObject nearest_enemy = null;
        foreach (GameObject enemy in enemy_inframe)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearest_distance )
            {
                nearest_distance = distance;
                nearest_enemy = enemy;
            }
        }

        if (nearest_enemy != null && nearest_distance <= tracking_range)
        {
            target = nearest_enemy.transform;
        }
        else
        {
            target = null;
        }

    }
    void Update()
    {
        if (target != null && target.transform.position.y > transform.position.y)
        {
            float rotation_step = 1/tracking_strength;

            Vector3 relativePos = target.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis((angle - 90f)/rotation_step, Vector3.forward);
        }

        transform.position = Vector2.MoveTowards(transform.position, head.transform.position, (speed * Time.deltaTime));
    }
}
