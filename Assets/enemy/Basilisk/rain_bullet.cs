using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain_bullet : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 rainPosition;
    private Vector3 endPosition;
    private float time = 0f;
    public float rainTime;
    public float waitTime;
    public float endTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        float randomX = Random.Range(-4.8f, 4.8f);
        rainPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        endPosition = new Vector3(randomX, -8.7f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= rainTime)
        {
            float percentage = time / rainTime;
            transform.position = Vector3.Lerp(startPosition, rainPosition, percentage);
        }
        else if (time <= rainTime + waitTime + endTime)
        {
            float percentage = (time-waitTime-rainTime) / endTime;
            transform.position = Vector3.Lerp(rainPosition, endPosition, percentage);
        }
        else
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;
    }
}
