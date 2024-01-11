using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    [SerializeField] float deadzone;
    [SerializeField] float speed;
    [SerializeField] int damage;
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;

        if (transform.position.y > deadzone)
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
        }
    }
}
