using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public Vector2 start_pos;
    public Vector2 player_pos;
    private Vector2 direction;
    public float bullet_speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(player_pos.x - start_pos.x, player_pos.y - start_pos.y).normalized;
        
    }
    void OnEnable()
    {
        direction = new Vector2(player_pos.x - start_pos.x, player_pos.y - start_pos.y).normalized;
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime * bullet_speed);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
           Player player = target.gameObject.GetComponent<Player>();
           Player.health-=1;
           Destroy(gameObject);
        }
    }
}
