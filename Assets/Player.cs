using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerbody;
    [SerializeField] float move_speed;
    [SerializeField] float shift_modifier;

    private LineRenderer lineRenderer;
    private int pointsCount = 50;
    private float angleBetweenPoints = 7.2f;
    private float maxR = 5.0f;
    public static int health;
    float speed;
    public Bomb BombEquipped = new Bomb();

    public class Bomb
    {
        public string Type;
        public int Stock;
    }

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount + 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 300;   
        BombEquipped.Type = "Default";
        BombEquipped.Stock = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = move_speed * shift_modifier;
        }
        else
        {
            speed = move_speed;
        }

        if(BombEquipped.Stock > 0 && Input.GetKeyDown(KeyCode.E))
        {
            if(BombEquipped.Type == "Default")
            {
                StartCoroutine(Blast());
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, maxR);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Enemy"))
                    {
                        enemy_behaviour enemy = hitCollider.gameObject.GetComponent(typeof(enemy_behaviour)) as enemy_behaviour;
                        enemy.Damage(4);
                    }
                    if (hitCollider.gameObject.CompareTag("EnemyBullet"))
                    {
                        Destroy(hitCollider.gameObject);
                    }

                }
            }
            else if (BombEquipped.Type == "Stopwatch")
            {
                StartCoroutine(Stopwatch());
            }
            BombEquipped.Stock -= 1;
        }


    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);

        playerbody.velocity = (move * speed);
    }


    private IEnumerator Stopwatch()
    {
        float timer = 0.0f;
        float timescale = 1.0f;
        while(timer < 2.0f)
        {
            float t = timer - 1.0f;
            timescale = t*t*t*t;
            enemy_behaviour.timescaler = timescale;
            enemy_bullet.timescaler = timescale;
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Blast()
    {
        float currR = 0.0f;
        while(currR < maxR)
        {
            currR += Time.deltaTime * 20.0f;
            Draw(currR);
            yield return null;
        }
    }

    private void Draw(float currR)
    {
        for(int i = 0; i <= pointsCount; i++)
        {
            float angle = i * angleBetweenPoints * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0.0f);
            Vector3 pos = dir * currR;

            lineRenderer.SetPosition(i, pos);
        }

        lineRenderer.widthMultiplier = Mathf.Lerp(0.0f, 1.0f, 1.0f - currR / maxR);
    }

}
