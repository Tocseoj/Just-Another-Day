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
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeTillGreen <= 0f)
            {
                accelerometerNeedle.transform.Rotate(new Vector3(0f,0f,0.15f));
				GameController.control.PlayerWon(2f);	// Victory Condition
            }
            else
            {
				GameController.control.PlayerLost(2f);
            }
        }
    }
}
