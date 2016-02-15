using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {
    public Sprite[] states;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject keyHole;
    public bool follow;
    private Vector3 mousePos;
    public bool inKeyHole;
    public handle doorknob;
    public bool unlocked;
    public bool grabbed;
	

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-4, 4)*25, Random.Range(-4, 4)*25);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !inKeyHole)
        {
            follow = true;
        }
    }

    void Update()
    {
        if (follow && !grabbed)
        {
            rb.velocity = Vector2.zero;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            rb.angularVelocity = 0f;
            grabbed = true;
        }

        if (!inKeyHole && !unlocked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
            if (Input.GetMouseButtonUp(0))
                follow = false;
            if (follow)
            {
                rb.velocity = (-transform.position + mousePos) * 5f;
                sr.sprite = states[0];
                if(transform.rotation.z != 0)
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }


            if (transform.position.x > 300f)
                transform.position = new Vector3(300f, transform.position.y, transform.position.z);
            else if (transform.position.x < -80f)
                transform.position = new Vector3(-80f, transform.position.y, transform.position.z);

            if (transform.position.y > 41f)
                transform.position = new Vector3(transform.position.x, 41f, transform.position.z);
            else if (transform.position.y < -41f)
                transform.position = new Vector3(transform.position.x, -41f, transform.position.z);
        }
        else if (Input.GetMouseButtonUp(0) && follow && !unlocked)
        {
            follow = false;
            transform.Rotate(new Vector3(0f, 0f, -15f));
            keyHole.transform.Rotate(new Vector3(0f, 0f, -15f));
            unlocked = true;
        }
        else if (unlocked)
        {
            doorknob.unlocked = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.Equals(keyHole) && follow)
        {
            sr.sprite = states[1];
            inKeyHole = true;
            transform.position = keyHole.transform.position;
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!grabbed)
            rb.velocity = new Vector2(Random.Range(-4,4)*25, Random.Range(-1, 1)*25);
    }
}
