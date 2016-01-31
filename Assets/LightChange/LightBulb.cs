using UnityEngine;
using System.Collections;

public class LightBulb : MonoBehaviour {

	public float movementSpeed = 10f;
	public SpriteRenderer lightAura;
	public Collider2D box;

	Vector3 offset;
	Vector3 mousePos;
	bool isIn = false;

	Rigidbody2D rb;
	Transform lamp;
	AudioSource aud;

	float nextScene = 0f;
	bool next = false;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		aud = GetComponent<AudioSource>();
		if (box != null) 
			Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), box);
	}

	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);

		if (isIn) {
			transform.position = lamp.position;
			transform.rotation = lamp.rotation;
			if (lightAura != null) {
				lightAura.enabled = true;
			}
			if (name == "NewBulb") {
				Debug.Log("Victory!");
				StartTimer();
			}
		}


		if (next) {
			if (nextScene < Time.time - 3/*seconds*/) {
				GameController.control.NextScene();
			}
		}
	}

	void OnMouseDown() {
		offset = transform.position - mousePos;
	}

	void OnMouseDrag() {
		rb.MovePosition(Vector2.Lerp(transform.position, mousePos + offset, Time.deltaTime * movementSpeed));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Plug") {
				lamp = other.transform;
				isIn = true;			
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		aud.Play();
	}

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
