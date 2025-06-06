using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector2 dir;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector2 screenBounds;

    [SerializeField]
    private BoxCollider2D col;
    private float pWidth;
    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)); 
    }
    private void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        pWidth = transform.localScale.x;
    }
    private void FixedUpdate()
    {
        if((transform.position.x >= screenBounds.x-pWidth/2) && dir.x > 0)
            Debug.LogWarning("OUT OF BOUNDS LEFT");
            //transform.Translate(Vector2.zero * speed * Time.fixedDeltaTime);
        else if((transform.position.x <= -screenBounds.x+pWidth/2) && dir.x < 0)
            Debug.LogWarning("OUT OF BOUNDS RIGHT");
            //transform.Translate(Vector2.zero * speed * Time.fixedDeltaTime);
        else
            transform.Translate(dir * speed * Time.fixedDeltaTime);
    }
    public BoxCollider2D getCollider()
    {
        return col;
    }
    public void enlarge(float size)
    {
        float oldScale = transform.localScale.x;
        size += oldScale;
        Vector2 newScale = new Vector2(size,transform.lossyScale.y);
        transform.localScale = newScale;
    }
    public void addSpeed(float speed)
    {
        this.speed += speed;
    }
}
