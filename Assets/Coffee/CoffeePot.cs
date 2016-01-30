using UnityEngine;
using System.Collections;

public class CoffeePot : MonoBehaviour {

	public float movementSpeed = 10f;
	public float rotationSpeed = 1f;

	Vector3 offset;
	Vector3 mousePos;
	bool held = false;

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);
		// Debug.Log("mousePos X: " + mousePos.x + " Y: " + mousePos.y);

		if (!held) {
			if (Input.GetKey(KeyCode.D)) {
				rb.MoveRotation(rb.rotation - rotationSpeed);
			} else if (Input.GetKey(KeyCode.A)) {
				rb.MoveRotation(rb.rotation + rotationSpeed);
			}
		}

		if (transform.rotation.z > 180 && transform.rotation.z < 333) {
			PourCoffee();
		}

		// transform.position = Vector3.MoveTowards(transform.position, mousePos, movementSpeed * Time.deltaTime);
	}

	void OnMouseDown() {
		offset = transform.position - mousePos;
		held = true;
	}

	void OnMouseDrag() {
		rb.MovePosition (Vector2.Lerp (transform.position, mousePos + offset, Time.deltaTime * movementSpeed));
	}

	void OnMouseUp() {
		held = false;
	}

	void PourCoffee() {
		Debug.Log("Pouring...");	
	}
}
