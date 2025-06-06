using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector2 dir;

    [SerializeField]
    private Vector2 screenBounds;

    [SerializeField]
    private float radius;
    
    [SerializeField]
    private OptionsMenu deathScreen;

    [SerializeField]
    private Player p;
    [SerializeField]
    private Bounds playerBounds;

    [SerializeField]
    private AudioSource brickHit;

    [SerializeField]
    private AudioSource reflectHit;

    [SerializeField]
    private AudioSource gameOver;
    
    [SerializeField]
    private AudioSource powerUP;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        dir = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;
    }
    private void Update()
    {
        playerBounds = p.getCollider().bounds;
    }
    private void FixedUpdate()
    {
        if(transform.position.x + radius > screenBounds.x)
        {
            reflectHit.Play();
            dir = Vector2.Reflect(dir * 1.5f,Vector2.right).normalized;
        }

        if(transform.position.x - radius < -screenBounds.x)
        {
            reflectHit.Play();
            dir = Vector2.Reflect(dir * 1.5f,Vector2.right).normalized;
        }
        
        if(transform.position.y + radius > screenBounds.y)
        {
            reflectHit.Play();
            dir = Vector2.Reflect(dir * 1.5f,Vector2.up).normalized;
        }

        if(transform.position.y + radius < -screenBounds.y)
        {
            gameOver.Play();
            deathScreen.setScreenText("game over!");
            deathScreen.getPoints();
            deathScreen.gameObject.SetActive(true);
            deathScreen.getBG().sizeDelta = new Vector2(Screen.width*2,Screen.height*2);
            Time.timeScale = 0;
        }
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            reflectHit.Play();
            ContactPoint2D contact = other.GetContact(0);
            Vector2 normal = contact.normal;
            dir = Vector2.Reflect(dir * 1.5f, -normal).normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Brick")
        {
            Brick b = other.GetComponent<Brick>();
            int chance = Random.Range(0,51);

            if(chance > 20)
                b.spawnPowerUP();

            brickHit.Play();
            Destroy(other.gameObject);
            dir = Vector2.Reflect(dir * 1.5f,Vector2.up).normalized;
        }
        if(other.gameObject.tag == "PowerUP")
        {
            PowerUP p = other.GetComponent<PowerUP>();
            powerUP.Play();
            p.applyPowerUP(this);
        }
    }
    public void enlarge(float size)
    {
        float oldScale = transform.localScale.x;
        size += oldScale;
        Vector2 newScale = new Vector2(size,size);
        transform.localScale = newScale;
    }
    public AudioSource getPowerUPSound()
    {
        return powerUP;
    }
    public float getRadius()
    {
        return radius;
    }
    public void addRadius(float radius) 
    {
        this.radius += radius;
    }
    public void addSpeed(float speed)
    {
        this.speed += speed;
    }
}
