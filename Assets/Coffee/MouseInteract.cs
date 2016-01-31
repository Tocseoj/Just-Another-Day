using UnityEngine;
using System.Collections;

public class MouseInteract : MonoBehaviour {

	public float movementSpeed = 10f;

	Vector3 offset;
	Vector3 mousePos;

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);
	}

	void OnMouseDown() {
		rb.velocity = (Vector2.zero);
		offset = transform.position - mousePos;
	}

	void OnMouseDrag() {
		rb.MovePosition (Vector2.Lerp (transform.position, mousePos + offset, Time.deltaTime * movementSpeed));
	}
}
