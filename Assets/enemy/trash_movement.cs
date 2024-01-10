using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_movement : MonoBehaviour
{
    public float move_speed;
    public float move_x;
    public float move_y;
    public int wave;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (wave == 2)
        {
            move_y *= 0.998f;
            move_x *= 1.002f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.lifetime += Time.deltaTime;

        transform.Translate(new Vector2(move_x, move_y) * move_speed * Time.deltaTime);
    }
}
