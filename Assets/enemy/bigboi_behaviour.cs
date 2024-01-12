using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigboi_behaviour : enemy_behaviour
{
    [SerializeField] GameObject Bullet;
    public float move_speed;
    public int wave;
    public float shoot_interval;

    private float timer;
    public Vector2 end_pos;

    private int amount = 3;

    private float[,] patternA = new float[,]{{0, -1}, 
                                              {0.707f, -0.707f}, 
                                              {1, 0},
                                              {0.707f, 0.707f},
                                              {0, 1},
                                              {-0.707f, 0.707f},
                                              {-1, 0},
                                              {-0.707f, -0.707f}
    };
    private float[,] patternB = new float[,]{{-5, 9, 5,  0}, //wave 1
                                             {-5, 5, 5,  0}, //wave 2
                                             {-5, 9, 5, -9}  //wave 3
    };
    // Start is called before the first frame update
    void Update()
    {
        if (timer < shoot_interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if(wave == 1)
            {
                for(int i = 0; i < 8; ++i)
                {
                    StartCoroutine(SpawnBullets(new Vector2(patternA[i, 0], patternA[i, 1]), amount));
                }
            }
            else
            {

            }
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
