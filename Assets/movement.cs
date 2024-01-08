using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerbody;
    [SerializeField] float move_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal") * move_speed;
        float y = Input.GetAxis("Vertical") * move_speed;
        playerbody.velocity = new Vector2(x, y);


    }
    
}
