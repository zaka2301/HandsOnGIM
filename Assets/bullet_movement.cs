using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    [SerializeField] float deadzone;
    [SerializeField] float speed;
    [SerializeField] int damage;
    public static float damage_multiplier = 1.0f;
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + (Vector3.up * speed) * Time.fixedDeltaTime;

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
           enemy_behaviour enemy = target.gameObject.GetComponent(typeof(enemy_behaviour)) as enemy_behaviour;
           enemy.Damage((int)(damage * damage_multiplier));
           Destroy(gameObject);
        }
    }
}
