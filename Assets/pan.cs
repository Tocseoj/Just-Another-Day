using UnityEngine;
using System.Collections;

public class pan : MonoBehaviour {
    private bool follow = false;
    private Rigidbody2D rb;
    public GameObject pancakeOtherSide;
    public Vector3 mousePos;

	float nextScene = 0f;
	bool next = false;

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

		if (next) {
			if (nextScene < Time.time - 3/*seconds*/) {
				GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
				GameController.control.NextScene();
			}
		}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(pancakeOtherSide))
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

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
