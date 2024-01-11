using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    private int health;
    public float lifetime = 0.0f;

    public Vector2 start_pos;
    // Start is called before the first frame update

    void Awake()
    {
        Destroy(gameObject, 3);
        start_pos = transform.position;
    }
    void LateUpdate()
    {
        lifetime += Time.deltaTime;
        if (health <= 0) Destroy(gameObject);
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        
    }

    public void SetHealth(int hp)
    {
        health = hp;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Shoot(GameObject BulletPrefab, Vector2 target, float speed)
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation) as GameObject;
        enemy_bullet bullet_property = bullet.GetComponent<enemy_bullet>();
        bullet_property.player_pos = target;
        bullet_property.bullet_speed = speed;
    }



}
