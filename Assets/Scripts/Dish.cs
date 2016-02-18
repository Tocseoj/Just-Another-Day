using UnityEngine;
using System.Collections;

public class Dish : MonoBehaviour {
    private Rigidbody2D rb;
    public Vector3 mousePos;
    float nextScene = 0f;
    bool next = false;
    private bool follow;
    public float percentClean;
    public Sprite clean;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            follow = true;
        }
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        if (Input.GetMouseButtonUp(0))
            follow = false;
        if (follow)
            rb.velocity = (-transform.position + mousePos) * 5f;

        if (transform.position.x > 300f)
            transform.position = new Vector3(300f, transform.position.y, transform.position.z);
        else if (transform.position.x < -80f)
            transform.position = new Vector3(-80f, transform.position.y, transform.position.z);

        if (transform.position.y > 41f)
            transform.position = new Vector3(transform.position.x, 41f, transform.position.z);
        else if (transform.position.y < -41f)
            transform.position = new Vector3(transform.position.x, -41f, transform.position.z);

        if (percentClean >= 100)
        {
            GetComponent<SpriteRenderer>().sprite = clean;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Water"))
        {
            percentClean += 0.1f;
        }
    }
}
