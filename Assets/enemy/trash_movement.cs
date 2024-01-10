using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_movement : MonoBehaviour
{
    public float move_speed;
    public int wave_type;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(wave_type)
        {
            case 1:
                transform.Translate(new Vector2(1, -2) * move_speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(new Vector2(1, -1) * move_speed * Time.deltaTime);
                break;
            default:
                break;

        }
    }
}
