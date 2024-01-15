using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_behaviour : enemy_behaviour
{
    [SerializeField] GameObject Bullet;

    private float timer;
    private int amount = 3;
    private Vector2 left_fang;
    private Vector2 right_fang;

    private int max_health;

    private bool is_attacking = false;

    private float[,] patternA = new float[,]{{0, -1}, 
                                             {0.707f, -0.707f}, 
                                             {1, 0},
                                             {0.707f, 0.707f},
                                             {0, 1},
                                             {-0.707f, 0.707f},
                                             {-1, 0},
                                             {-0.707f, -0.707f}
    };
    private float[,] patternA2 = new float[,]{{0.382f, 0.924f}, 
                                              {0.924f, 0.382f}, 
                                              {0.924f, -0.382f},
                                              {0.382f, -0.924f},
                                              {-0.382f, -0.924f},
                                              {-0.924f, -0.382f},
                                              {-0.924f, 0.382f},
                                              {-0.382f, 0.924f}
    };
    private float[,] patternB = new float[,]{{0,-1}, 
                                             {0.5f, -0.866f}, 
                                             {-0.5f, -0.866f}  
    };
    // Start is called before the first frame update
    void Start()
    {
        
        max_health = GetHealth();

    }

    // Update is called once per frame
    void Update()
    {
        if(is_attacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), Time.deltaTime * 6.0f);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,10), Time.deltaTime * 4.0f);

        }
        if (timer < shoot_interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (GetHealth() > (max_health / 2))
            {
                left_fang  = new Vector2(transform.position.x - 1.31f, transform.position.y - 6.89f);
                right_fang = new Vector2(transform.position.x + 1.31f, transform.position.y - 6.89f);
                for(int i = 0; i < 3; ++i)
                {
                    StartCoroutine(SpawnBullets(left_fang, new Vector2(left_fang.x + patternB[i, 0], left_fang.y + patternB[i, 1]), amount, 0.2f));
                }
                for(int i = 0; i < 3; ++i)
                {
                    StartCoroutine(SpawnBullets(right_fang, new Vector2(right_fang.x + patternB[i, 0], right_fang.y + patternB[i, 1]), amount, 0.2f));
                }
                timer -= shoot_interval;
            }

            else
            {
                StartCoroutine(AttackB());
                timer -= shoot_interval;
                shoot_interval = 10.0f;
            }
            
        } 
    }
    IEnumerator AttackB()
    {
        is_attacking = true;
        yield return new WaitForSeconds(2.0f);
        for(int i = 0; i < 8; ++i)
        {
            StartCoroutine(SpawnBullets(transform.position, new Vector2(transform.position.x + patternA[i, 0] , transform.position.y + patternA[i, 1]) , 8, 0.1f));
        }
        yield return new WaitForSeconds(0.2f);
        for(int i = 0; i < 32; ++i)
        {
            if (i%4!=0)
            {
            StartCoroutine(SpawnBullets(transform.position, new Vector2(transform.position.x + Mathf.Sin(0.1963f * i), transform.position.y + Mathf.Cos(0.1963f * i)), 4, 0.2f));
            }
        }
        yield return new WaitForSeconds(3.0f);
        is_attacking = false;
    }

    IEnumerator SpawnBullets(Vector2 start, Vector2 target, int amount, float delay)
    {

        for(int i = 0; i < amount; ++i)
        { 
            Shoot(Bullet, start, target, 6.25f);
            yield return new WaitForSeconds(delay);  
        }
        
    }
}
