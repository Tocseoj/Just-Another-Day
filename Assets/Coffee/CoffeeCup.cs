using UnityEngine;
using System.Collections;

public class CoffeeCup : MonoBehaviour {

	public int winAmt = 30;
	public Sprite fullCoffeeBack;

	int count;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Coffee") {
			count++;
			// Debug.Log("Count: " + count);
		}

		if (count >= winAmt) {
			Debug.Log("YOU WIN!");
			transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = fullCoffeeBack;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Coffee") {
			count--;
			Debug.Log("Count: " + count);
		}
	}
}
