using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static Timer staticTimer;

	public Sprite[] sprites = new Sprite[11];

	SpriteRenderer timerSprite;

	float timer = 0f;
	public int clock = 11;

	float nextSceneTimer = 0f;
	bool next = false;
	public bool stopped = false;

	bool doOnce = true;

	// Use this for initialization
	void Awake () {
		staticTimer = this;
		timerSprite = GetComponent<SpriteRenderer>();
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopped) {
			if (timer < Time.time - 1f) {
				clock = Mathf.Clamp(clock - 1, 0, 10);
				timerSprite.sprite = sprites[clock];
				timer = Time.time;
				if (clock == 0) {
					StartTimer();
				}
			}
		}

		if (next) {
			if (doOnce) {
				GameObject light = GameObject.Find("VendingMachineLight");
				if (light != null) {
					if (light.GetComponent<SpriteRenderer>().enabled == true) {
						GameController.control.hidden[6] = true;
					}
				}
				doOnce = false;
			}
			if (nextSceneTimer < Time.time - 3/*seconds*/) {
				GameController.control.NextScene();
			}
		}
	}

	void StartTimer() {
		if (!next) {
			nextSceneTimer = Time.time;
			next = true;
		}
	}

	public void StopClock() {
		stopped = true;

	}
}
