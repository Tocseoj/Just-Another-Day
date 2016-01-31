using UnityEngine;
using System.Collections;

public class VendingMachine : MonoBehaviour {

	public float force = 1000f;

	Rigidbody2D rb;
	public AudioSource audioSource;
	public AudioSource audioSource2;

	public int hits = 2;

	public SpriteRenderer lightSprite;

	float timer = 0f;

	float nextScene = 0f;
	bool next = false;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
		// Debug.Log(Input.mousePosition);
		if (Input.GetMouseButtonDown(0)) {
			if (timer < Time.time - 0.3) {
				audioSource2.Play();
				if (rb.freezeRotation) {
					rb.freezeRotation = false;
				}
				if (Input.mousePosition.x < Screen.width / 2/*Random.value < 0.5*/) {
					rb.AddForce(new Vector2(force, 0));
				} else {
					rb.AddForce(new Vector2(-force, 0));
				}
				hits--;
				if (hits == 0) {
					lightSprite.enabled = false;
					audioSource.Play();
				}
				timer = Time.time;
			}
		}


		if (next) {
			if (nextScene < Time.time - 3/*seconds*/) {
				GameController.control.NextScene();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Snack") {
			Debug.Log("VICTORY!");
			GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
			Timer.staticTimer.StopClock();
			StartTimer();
		}
	}

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
