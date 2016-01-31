using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject flag;
    public bool lookingRight = true;

	float nextScene = 0f;
	bool next = false;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (next) {
			if (nextScene < Time.time - 3/*seconds*/) {
				GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
				GameController.control.NextScene();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject == flag) {
			Debug.Log("Victory!");
			// GameController.control.hidden[2] = true;
			StartTimer();
			Timer.staticTimer.StopClock();
			GameObject go = GameObject.Find("Check");
			go.GetComponent<SpriteRenderer>().enabled = true;
			go.GetComponent<AudioSource>().enabled = true;
		}
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

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
