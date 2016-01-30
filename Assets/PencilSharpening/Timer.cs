using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public Sprite[] sprites = new Sprite[11];

	SpriteRenderer timerSprite;

	float timer = 0f;
	int clock = 11;

	// Use this for initialization
	void Awake () {
		timerSprite = GetComponent<SpriteRenderer>();
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < Time.time - 1f) {
			clock = Mathf.Clamp(clock - 1, 0, 10);
			timerSprite.sprite = sprites[clock];
			timer = Time.time;
		}
	}
}
