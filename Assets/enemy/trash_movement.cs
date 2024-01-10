using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_movement : MonoBehaviour
{
    public float move_speed;
    public float move_x;
    public float move_y;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(move_x, move_y) * move_speed * Time.deltaTime);
    }
}
