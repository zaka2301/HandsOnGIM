using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_tracking : MonoBehaviour
{
    public Transform target;
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
    
}
