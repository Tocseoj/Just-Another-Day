using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static Timer staticTimer;

	public Sprite[] sprites = new Sprite[11];

	SpriteRenderer timerSprite;

	float timer = 0f;
	public int clock = 10;
	bool stopped;

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
					GameController.control.PlayerLost(2f);
				}
			}
		}
	}

	public void StopClock() {
		stopped = true;
	}
}