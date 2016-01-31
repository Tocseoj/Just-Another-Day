using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject flag;
    public bool lookingRight = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void MoveRight()
    {
        rb.AddRelativeForce(Vector3.right * 1000);
        if (!lookingRight)
            flip();
    }

    public void MoveLeft()
    {
        rb.AddRelativeForce(Vector3.right * -1000);
        if (lookingRight)
            flip();
    }

    public void MoveUp()
    {
        rb.AddRelativeForce(Vector3.up * 1000);
    }

    public void flip()
    {
        lookingRight = !lookingRight;
        sr.flipX = !sr.flipX;
    }
}
