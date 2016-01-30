using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	private float timer;

	void Awake() {
		timer = Time.time;
	}

	void LateUpdate() {
		if (timer < Time.time - 2) {
			if (GameObject.FindGameObjectWithTag("Pencil") == null) {
				Debug.Log("YOU LOSE!");
			}
			timer = Time.time;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.gameObject.tag.Equals("Pencil")) {
			Destroy(other.collider.gameObject);
		} else {
			Destroy(other.collider.gameObject);
		}
	}
}