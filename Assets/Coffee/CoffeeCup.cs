using UnityEngine;
using System.Collections;

public class CoffeeCup : MonoBehaviour {

	public int winAmt = 30;
	public Sprite fullCoffeeBack;

	int count;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Coffee") {
			count++;
		}

		if (count >= winAmt) {
			transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = fullCoffeeBack;
			if (name == "Mug") {
				Debug.Log("Victory!");
				GameController.control.PlayerWon(2f);	// Victory Condition
			} else if (name == "Vase") {
				GameController.control.PlayerLost(2f);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Coffee") {
			count--;
		}
	}
}
