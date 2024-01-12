using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    
    private int health;
    public float lifetime = 0.0f;

    public Vector2 start_pos;

    public bool in_zone = true;
    // Start is called before the first frame update

    void Awake()
    {
        start_pos = transform.position;
    }
    void LateUpdate()
    {
        lifetime += Time.deltaTime;
        if (health <= 0) Destroy(gameObject);
        if (transform.position.x > -6 && transform.position.x < 6 && transform.position.y > -10  && transform.position.y < 10 )
        {
            in_zone = true;
        }
        else
        {
            Destroy(gameObject);
        }
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
        if (in_zone){
            //GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation) as GameObject;
            GameObject bullet = ObjectPoolManager.SpawnObject(BulletPrefab, transform.position, transform.rotation, ObjectPoolManager.PoolType.Gameobject);
            enemy_bullet bullet_property = bullet.GetComponent<enemy_bullet>();
            bullet_property.player_pos = target;
            bullet_property.bullet_speed = speed;
        }
    }



}
