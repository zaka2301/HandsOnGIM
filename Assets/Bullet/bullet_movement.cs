using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : bullet_behaviour
{
    void Update()
    {
        transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;
    }

    
}
