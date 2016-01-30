using UnityEngine;
using System.Collections;

public class PencilSharpening : MonoBehaviour {

	public float movementSpeed = 10f;

	Vector3 offset;
	Vector3 mousePos;

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);
		// Debug.Log("mousePos X: " + mousePos.x + " Y: " + mousePos.y);

		// transform.position = Vector3.MoveTowards(transform.position, mousePos, movementSpeed * Time.deltaTime);
	}

	void OnMouseDown() {
		offset = transform.position - mousePos;
	}

	void OnMouseDrag() {
		rb.MovePosition (Vector2.Lerp (transform.position, mousePos + offset, Time.deltaTime * movementSpeed));
	}
}
