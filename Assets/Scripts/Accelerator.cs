﻿using UnityEngine;
using System.Collections;

public class Accelerator : MonoBehaviour {
    public float timeTillGreen;
    public GameObject background;
    public GameObject accelerometerNeedle;
    public Sprite backgroundLightOn;
    public AudioClip[] carHorns;
    public float timeBetweenHorns = 0.5f;
    public AudioSource audioSource;

	float nextScene = 0f;
	bool next = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeTillGreen = Random.Range(4,8);
    }

	// Update is called once per frame
	void Update () {
        timeTillGreen -= Time.deltaTime;

        if (timeTillGreen <= 0f)
        {
            timeBetweenHorns -= Time.deltaTime;
            background.GetComponent<SpriteRenderer>().sprite = backgroundLightOn;
            /*
            if (timeBetweenHorns <= 0f && !audioSource.isPlaying)
            {
                timeBetweenHorns = Random.value;
                audioSource.clip = carHorns[Random.Range(0, 2)];
                audioSource.Play();
            }
            */
        }

		if (next) {
			if (nextScene < Time.time - 1/*seconds*/) {
				GameController.control.score[GameController.control.day] += 5 * 10;
				GameController.control.NextScene();
			}
		}
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeTillGreen <= 0f)
            {
                accelerometerNeedle.transform.Rotate(new Vector3(0f,0f,0.15f));
                Debug.Log("Victory");
				GameObject go = GameObject.Find("Check");
				go.GetComponent<SpriteRenderer>().enabled = true;
				go.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                Debug.Log("Fail");
				GameController.control.hidden[4] = true;
				GameObject go = GameObject.Find("X");
				go.GetComponent<SpriteRenderer>().enabled = true;
				go.GetComponent<AudioSource>().enabled = true;
            }
			Timer.staticTimer.StopClock();
			StartTimer();
        }
    }

	void StartTimer() {
		if (!next) {
			nextScene = Time.time;
			next = true;
		}
	}
}
