using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {
    public GameObject clock;
    public GameObject arm;
    private SpriteRenderer clockSR;
    public bool on = true;
    public int currentSprite = 0;
    public Sprite[] frames;
    private int changeEveryFrames;
    public float nextSceneIn = 2f;
    public float timeTillNext;

	float nextScene = 0f;
	bool next = false;

	// Use this for initialization
	void Start () {
        clockSR = clock.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            if (changeEveryFrames >= 10)
            {
                animate();
                changeEveryFrames = 0;
            }
            else
            {
                changeEveryFrames++;
            }
        }
        else
        {
            timeTillNext += Time.deltaTime;
            if (timeTillNext >= nextSceneIn)
            {
				
            }
			// GameController.control.hidden[7] = true;
			Timer.staticTimer.StopClock();
			StartTimer();
        }

		if (next) {
			if (nextScene < Time.time - 1/*seconds*/) {
				GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
				GameController.control.NextScene();
			}
		}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == arm)
        {
            on = false;
            GetComponent<AudioSource>().Stop();
            clockSR.sprite = frames[0];
        }
    }

    private void animate()
    {
        if (frames.Length <= 0)
            return;
        if (currentSprite < frames.Length)
        {
            clockSR.sprite = frames[currentSprite];
            currentSprite++;
        }
        else
        {
            currentSprite = 0;
            animate();
        }
    }

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
