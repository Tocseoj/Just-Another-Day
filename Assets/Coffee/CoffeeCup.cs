using UnityEngine;
using System.Collections;

public class CoffeeCup : MonoBehaviour {

	public int winAmt = 30;
	public Sprite fullCoffeeBack;

	int count;

	float nextScene = 0f;
	bool next = false;

	void Update() {
		if (next) {
			if (nextScene < Time.time - 3/*seconds*/) {
				GameController.control.NextScene();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Coffee") {
			count++;
			// Debug.Log("Count: " + count);
		}

		if (count >= winAmt) {
			Debug.Log("YOU WIN!");
			StartTimer();
			Timer.staticTimer.StopClock();
			transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = fullCoffeeBack;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Coffee") {
			count--;
			// Debug.Log("Count: " + count);
		}
	}

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
