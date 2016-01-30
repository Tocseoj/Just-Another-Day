using UnityEngine;
using System.Collections;

public class PencilSharpener : MonoBehaviour {

	bool engaged = false;
	Vector3 offset;
	Vector3 mousePos;
	Rigidbody2D rb;
	public float movementSpeed = 10f;
	public float upperBound = 100f;
	public float lowerBound;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (engaged) {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals("Pencil")) {
			other.attachedRigidbody.velocity = Vector2.zero;
			other.GetComponent<PencilSharpening>().enabled = false;
			engaged = true;
		}
	}

	void OnMouseDown() {
		if (engaged) {
			offset = transform.position - mousePos;
		}
	}

	void OnMouseDrag() {
		if (engaged) {
			Debug.Log("mousePos X: " + mousePos.x + " Y: " + mousePos.y);
			rb.MovePosition(Vector2.Lerp(transform.position, mousePos + offset, Time.deltaTime * movementSpeed));
		}
	}
}
