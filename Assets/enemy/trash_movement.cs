using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_movement : MonoBehaviour
{
    [SerializeField] float ah;
    public float move_speed;
    public float move_x;
    public float move_y;
    public int wave;
    public float lifetime;

    private Vector3 start_pos;
    public Vector3 end_pos;
    public Vector3 mid_pos;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
        this.lifetime = 0.0f;
        start_pos = transform.position;
    }

    void Update()
    {
        /*
        if (wave == 2)
        {
            move_y += Mathf.Exp(-lifetime* move_speed * ah) * Time.deltaTime;
            move_x += Mathf.Exp(-lifetime* move_speed * ah) * Time.deltaTime;
        }
        */
    }


    private static Vector3 quadBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return (1-t)*(1-t)*p0 + 2*(1-t)*t*p1 + t*t*p2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.lifetime += Time.fixedDeltaTime;
        if (wave == 2)
        {
            //quadratic bezier curve
            transform.position = quadBezier(start_pos, mid_pos, end_pos, lifetime * move_speed);
            
            //transform.position = Vector3.Lerp(start_pos, end_pos, lifetime * move_speed);
            //transform.Translate(new Vector2(move_x, move_y) * move_speed * Time.deltaTime);
        }
        else
        {
            //transform.Translate(new Vector2(move_x, move_y) * move_speed * Time.deltaTime);
            transform.position = Vector3.Lerp(start_pos, end_pos, lifetime * move_speed);
        }
        //transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(10, -3, 0), move_speed * Time.fixedDeltaTime);
    }
}
