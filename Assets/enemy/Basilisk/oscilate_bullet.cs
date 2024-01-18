using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilate_bullet : MonoBehaviour
{
    public float bullet_speed;
    public float amplitude;
    public float vertical_speed;
    private Vector2 direction;
    public float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Mathf.Cos(0.5f+time*bullet_speed)*amplitude, -vertical_speed);
        transform.Translate(direction * Time.deltaTime * bullet_speed);


        time += Time.deltaTime;

        if (transform.position.y <= -8.7f)
        {
            Destroy(gameObject);
        }
    }
}
