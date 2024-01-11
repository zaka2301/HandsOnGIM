using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitch_behaviour : MonoBehaviour
{
    public float move_speed;
    public int wave;
    public float lifetime;

    private Vector2 start_pos;
    public Vector2 end_pos;
    public Vector2 mid_pos;

    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
        this.lifetime = 0.0f;
        start_pos = this.transform.position;
        
    }

    void Update()
    {

    }

    private static Vector2 QuadBezier(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        return (1-t)*(1-t)*p0 + 2*(1-t)*t*p1 + t*t*p2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.lifetime += Time.fixedDeltaTime;


        switch(wave)
        {
            case 1:
                //quadratic bezier curve
                transform.position = QuadBezier(start_pos, mid_pos, end_pos, lifetime * move_speed);
                break;

            default:
                transform.position = Vector2.LerpUnclamped(start_pos, end_pos, lifetime * move_speed);
                break;

        }


        // after lot of testing, lerping seems like the best
 
            
        //transform.position = Vector3.Lerp(start_pos, end_pos, lifetime * move_speed);
        //transform.Translate(new Vector2(move_x, move_y) * move_speed * Time.deltaTime);
        //transform.Translate(direction * move_speed * Time.fixedDeltaTime);
        //transform.Translate(new Vector2(move_x, move_y) * move_speed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, end_pos, Time.fixedDeltaTime * move_speed);
        
    }
}
