using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{

    public int wave;
    public float move_speed;
    public float shoot_chance;
    public float shoot_interval;

    
    private int health;
    public float lifetime = 0.0f;

    public static float timescaler = 1.0f;

    public Vector2 start_pos;
    public Vector2 end_pos;

    public bool in_zone = false;
    // Start is called before the first frame update

    public void LateUpdate()
    {
        lifetime += Time.deltaTime * timescaler;
        if (health <= 0) OnDeath();

    }

    public void OnDeath()
    {
        Destroy(gameObject);
        ScoreManager.instance.killScore(Random.Range(2500,5000));
        ExperienceManager.instanceExperienceManager.AddExperience(Random.Range(1,100));
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        ScoreManager.instance.DmgScore(Random.Range(500,1000));
        
    }

    public void SetHealth(int hp)
    {
        health = hp;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Shoot(GameObject BulletPrefab, Vector2 start, Vector2 target, float speed)
    {
        if(in_zone)
        {
            //GameObject bullet = Instantiate(BulletPrefab, start, transform.rotation) as GameObject;
            //fix this shit 
            ObjectPoolManager.SpawnObject(BulletPrefab, start, transform.rotation, target, 6.5f, ObjectPoolManager.PoolType.Gameobject);

        }
    }



}
