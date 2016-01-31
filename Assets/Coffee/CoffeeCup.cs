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
				GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
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
			transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = fullCoffeeBack;
			if (name == "Mug") {
				Debug.Log("VICTORY!");
			} else if (name == "Vase") {
				GameController.control.hidden[2] = true;
			}
			StartTimer();
			Timer.staticTimer.StopClock();
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
