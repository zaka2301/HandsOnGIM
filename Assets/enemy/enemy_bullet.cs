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
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(direction * Time.fixedDeltaTime * bullet_speed);
    }
}
