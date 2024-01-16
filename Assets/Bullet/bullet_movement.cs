using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    public Enemy_tracking enemy_tracking;
    public bullet_behaviour bullet_behaviour;
    public Transform head;
    private Transform target;
    private float tracking_strength;
    void Update()
    {
        target = enemy_tracking.target;
        tracking_strength = enemy_tracking.tracking_strength;
        if (target != null && target.transform.position.y > transform.position.y)
        {
            float rotation_step = 1 / tracking_strength;

            Vector3 relativePos = target.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis((angle - 90f) / rotation_step, Vector3.forward);
        }
        transform.position = Vector2.MoveTowards(transform.position, head.transform.position, (bullet_behaviour.speed * Time.deltaTime));
    }

    
}
