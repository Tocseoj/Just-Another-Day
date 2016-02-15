using UnityEngine;
using System.Collections;

public class Newspaper : MonoBehaviour {

    public GameObject fly;
    private Rigidbody2D rb;
    public Vector3 mousePos;
    float nextScene = 0f;
    bool next = false;
    private bool follow;
    private int numberOfFlies = 10;

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

        if (next)
        {
            if (nextScene < Time.time - 3/*seconds*/)
            {
                GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
                GameController.control.NextScene();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Fly") && col.relativeVelocity.magnitude > 1f)
        {
            col.gameObject.GetComponent<Fly>().kill();
            numberOfFlies -= 1;
            if (numberOfFlies <= 0)
            {
                // GameController.control.hidden[3] = true;
                Timer.staticTimer.StopClock();
                StartTimer();
                GameObject go = GameObject.Find("Check");
                go.GetComponent<SpriteRenderer>().enabled = true;
                go.GetComponent<AudioSource>().enabled = true;
                // GameController.control.NextScene();
            }
        }
    }

    void StartTimer()
    {
        if (!next)
        {
            nextScene = Time.time;
            next = true;
        }
    }
}
