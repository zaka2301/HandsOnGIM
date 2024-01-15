using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_behaviour : MonoBehaviour
{
    private float deadzone_x = 8f;
    private float deadzone_y = 13f;
    public float speed;
    [SerializeField] int damage;
    [SerializeField] int penetration;

    void LateUpdate()
    {
        if (transform.position.x > Mathf.Abs(deadzone_x) || transform.position.y > Mathf.Abs(deadzone_y))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            enemy_behaviour enemy = target.gameObject.GetComponent(typeof(enemy_behaviour)) as enemy_behaviour;
            enemy.Damage(damage);

            penetration -= 1;
            if (penetration <= 0) Destroy(gameObject);
        }
    }
}
