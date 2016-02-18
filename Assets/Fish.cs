using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {
    public Sprite[] frames;
    public int currentSprite;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public float timeTillFlap;
    private int changeEveryFrames;
    private bool facingRight;
    public int needsToEat = 30;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        timeTillFlap = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(needsToEat <= 0)
            GameController.control.PlayerWon(3f);

        if (rb.velocity.x < 0 && facingRight == true)
            Flip();
        else if (rb.velocity.x > 0 && facingRight == false)
            Flip();

        timeTillFlap -= Time.deltaTime;

        if (timeTillFlap <= 0)
        {
            rb.AddRelativeForce(new Vector2(Random.Range(-5000, 5000), Random.Range(-1000,1000)));
            timeTillFlap = timeTillFlap = Random.Range(0.5f, 2f);
        }

        if (changeEveryFrames >= 100f/rb.velocity.magnitude)
        {
            animate();
            changeEveryFrames = 0;
        }
        else
        {
            changeEveryFrames++;
        }
    }

    private void animate()
    {
        if (frames.Length <= 0)
            return;
        if (currentSprite < frames.Length)
        {
            sr.sprite = frames[currentSprite];
            currentSprite++;
        }
        else
        {
            currentSprite = 0;
            animate();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.tag.Equals("Water"))
        {
            Flip();
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Water") && needsToEat > 0)
        {
            Destroy(other.gameObject);
            needsToEat--;
        }
    }
}
