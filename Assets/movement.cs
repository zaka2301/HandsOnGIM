using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerbody;
    [SerializeField] float move_speed;
    [SerializeField] float shift_modifier;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = move_speed * shift_modifier;
        }
        else
        {
            speed = move_speed;
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);

        transform.Translate(move * speed * Time.deltaTime);
    }
    
}
