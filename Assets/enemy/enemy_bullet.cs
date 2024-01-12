using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public Vector2 player_pos;
    private Vector2 direction;
    public float bullet_speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(player_pos.x - transform.position.x, player_pos.y - transform.position.y).normalized;
        
    }

    void Update()
    {
        if(transform.position.x < -6 || transform.position.x > 6 || transform.position.y < -10  || transform.position.y > 10)
        {
            ObjectPoolManager.ReturnObjectToPool(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(direction * Time.fixedDeltaTime * bullet_speed);
    }
}
