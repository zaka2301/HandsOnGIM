using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerbody;
    [SerializeField] float move_speed;
    [SerializeField] float shift_modifier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = move_speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = move_speed * shift_modifier;
        }

        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;
        playerbody.velocity = new Vector2(x, y);

        


    }
    
}
