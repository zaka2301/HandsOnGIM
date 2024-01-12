using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallboi_behaviour : enemy_behaviour
{
    [SerializeField] GameObject Bullet;

    private float timer;

    private int amount = 3;

    void Update()
    {
        if (timer < shoot_interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            StartCoroutine(SpawnBullets(GameObject.FindGameObjectsWithTag("Player")[0].transform.position, amount));
            timer -= shoot_interval;
        }
    }
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(start_pos, end_pos, Mathf.SmoothStep(0.0f, 1.0f, lifetime * move_speed));
    }
    IEnumerator SpawnBullets(Vector2 target, int amount)
    {

        for(int i = 0; i < amount; ++i)
        { 
            Shoot(Bullet, target, 6.25f);
            yield return new WaitForSeconds(0.2f);  
        }
        
    }
}
