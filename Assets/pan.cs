using UnityEngine;
using System.Collections;

public class pan : MonoBehaviour {
    private bool follow = false;
    private Rigidbody2D rb;
    public GameObject pancakeOtherSide;

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
        if (Input.GetMouseButtonUp(0))
            follow = false;
        if (follow)
            rb.velocity = (-transform.position + new Vector3(-Screen.width / 2 + Input.mousePosition.x, -Screen.height / 2 + Input.mousePosition.y, 0)) * 5f;

        if (transform.position.x > 300f)
            transform.position = new Vector3(300f, transform.position.y, transform.position.z);
        else if (transform.position.x < -80f)
            transform.position = new Vector3(-80f, transform.position.y, transform.position.z);

        if (transform.position.y > 41f)
            transform.position = new Vector3(transform.position.x, 41f, transform.position.z);
        else if (transform.position.y < -41f)
            transform.position = new Vector3(transform.position.x, -41f, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(pancakeOtherSide))
        {
            Debug.Log("Victory");
        }
    }
}
