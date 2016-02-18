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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Fly") && col.relativeVelocity.magnitude > 1f)
        {
            col.gameObject.GetComponent<Fly>().kill();
            numberOfFlies -= 1;
            if (numberOfFlies <= 0)
            {
                GameController.control.PlayerWon(3f);
            }
        }
    }
}
