﻿using UnityEngine;
using System.Collections;

public class PencilSharpener : MonoBehaviour {

	bool engaged = false;
	Vector3 offset;
	Vector3 mousePos;
	Rigidbody2D rb;
	public float movementSpeed = 10f;
	public float upperBound;
	public float lowerBound;
	bool isUp = true;
	int turnCounter = 0;
	Transform lever;
	AudioSource audioSource;
	public int rotationsNeeded = 6;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		lever = GameObject.Find("HandleParent").transform;
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (engaged) {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);
		}

		if (turnCounter >= rotationsNeeded) {
			Debug.Log("VICTORY!");
			turnCounter = 0;
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
			if (transform.position.y > upperBound - 0.1f && !isUp) {
				isUp = true;
				turnCounter++;
				audioSource.Play();
			} else if (transform.position.y < lowerBound + 0.1f && isUp) {
				isUp = false;
				turnCounter++;
				audioSource.Play();
			}
			rb.MovePosition(Vector2.Lerp(transform.position, new Vector2(transform.position.x, Mathf.Clamp(mousePos.y + offset.y, lowerBound, upperBound)), Time.deltaTime * movementSpeed));

			lever.localScale = new Vector3(1f, ((((transform.position.y - lowerBound) / (upperBound - lowerBound)) - 0.5f) * 2f), 1f);
		}
	}
}
