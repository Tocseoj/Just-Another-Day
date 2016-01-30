using UnityEngine;
using System.Collections;

public class arm : MonoBehaviour {
    private bool follow = false;
    private Rigidbody2D rb;
    private Vector3 mousePos;

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
            rb.velocity = (-transform.position + mousePos)*5f;

        if (transform.position.x > 30f)
            transform.position = new Vector3(30f,transform.position.y, transform.position.z);
        else if(transform.position.x < -55f)
            transform.position = new Vector3(-55f, transform.position.y, transform.position.z);

        if (transform.position.y > 41f)
            transform.position = new Vector3(transform.position.x,41f,  transform.position.z);
        else if (transform.position.y < -41f)
            transform.position = new Vector3(transform.position.x,-41f,  transform.position.z);
    }
}
