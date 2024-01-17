using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerbody;
    [SerializeField] float move_speed;
    [SerializeField] float shift_modifier;
    public static int health;
    float speed;
    public Bomb BombEquipped = new Bomb();

    public class Bomb
    {
        public string Type;
        public int Stock;
    }


    private LineRenderer lineRenderer;
    private int pointsCount = 50;
    private float angleBetweenPoints = 7.2f;
    private float maxR = 5.0f;

    public static bool hit = false;
    private float i_timer = 0.0f;

    private SpriteRenderer spriteRenderer;



    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 3;   
        BombEquipped.Type = "Default";
        BombEquipped.Stock = 3;
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) OnDeath();

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

                foreach(var hitCollider in hitColliders)
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
            else if(BombEquipped.Type == "Shot Augment")
            {
                StartCoroutine(Augment());
            }
            else if(BombEquipped.Type == "Master Spark")
            {
                StartCoroutine(MasterSpark());
            }
            BombEquipped.Stock -= 1;
        }


        if (i_timer >= 3.0f)
        {
            i_timer = 0.0f;
            hit = false;
            spriteRenderer.enabled = true;
        }

        if (hit == true)
        {
            i_timer += Time.deltaTime;

            spriteRenderer.enabled = Mathf.FloorToInt(i_timer*3) % 2 != 0;
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

    private IEnumerator Augment()
    {
        float timer = 0.0f;
        float duration = 3.0f;
        bullet_movement.damage_multiplier = 2.0f;
        while(timer <= duration)
        {
            
            timer += Time.deltaTime;
            yield return null;
        }
        bullet_movement.damage_multiplier = 1.0f;
    }

    private IEnumerator MasterSpark()
    {
        float timer = 0.0f;
        float duration = 3.0f;
        Debug.LogWarning("Master Spark not implemented yet");

        while(timer <= duration)
        {
            timer += Time.deltaTime;
            //do shit here idk
            yield return null;
        }
    }

    private IEnumerator Blast()
    {
        float currR = 0.0f;
        lineRenderer.positionCount = pointsCount + 1;
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        while(currR < maxR)
        {
            Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, maxR);

            if (hitCollider.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(hitCollider.gameObject);
            }

            currR += Time.deltaTime * 20.0f;
            DrawBlast(currR);
            yield return null;
        }
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
    }


    private void DrawBlast(float currR)
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
