using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static Timer staticTimer;

	public Sprite[] sprites = new Sprite[11];

	SpriteRenderer timerSprite;

	float timer = 0f;
	int clock = 11;

	float nextScene = 0f;
	bool next = false;
	public bool stopped = false;

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
			if (nextScene < Time.time - 3/*seconds*/) {
				GameController.control.NextScene();
			}
		}
	}

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}

	public void StopClock() {
		stopped = true;
	}
}
