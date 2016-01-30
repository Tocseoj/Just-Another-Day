using UnityEngine;
using System.Collections;

public class CoffeePot : MonoBehaviour {

	public float movementSpeed = 10f;
	public float rotationSpeed = 1f;
	public int totalCoffeeAmt = 100;

	public Transform coffeePourPrefab;

	Vector3 mousePos;
	bool held = false;
	float timer;

	TargetJoint2D joint;
	Transform spout;
	private	AudioSource audioSource;

	void Awake() {
		joint = GetComponent<TargetJoint2D>();
		audioSource = GetComponent<AudioSource>();
		spout = transform.GetChild(0);
		timer = Time.time;
	}

	void Update () {

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0f);
		if (held) {
			if (joint != null) {
				joint.target = mousePos;
			}

		}

		// Debug.Log("Z Rotation: " + transform.rotation.z);
		if (transform.rotation.eulerAngles.z > 200f && transform.rotation.eulerAngles.z < 333f) {
			audioSource.UnPause();
			PourCoffee();
		} else {
			audioSource.Pause();
		}
	}

	void OnMouseDown() {
		held = true;
		joint.enabled = true;
	}

	void OnMouseUp() {
		held = false;
		joint.enabled = false;
	}

	void PourCoffee() {
		// Debug.Log("Pouring...");
		if (timer < Time.time - 0.15f) {
			if (totalCoffeeAmt > 0) {
				Instantiate(coffeePourPrefab, spout.position, transform.rotation);
				totalCoffeeAmt--;
			} else {
				Debug.Log("OUT OF COFFEE!");
				audioSource.Stop();
			}
			timer = Time.time;
		}
	}
}
