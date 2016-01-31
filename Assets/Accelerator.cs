﻿using UnityEngine;
using System.Collections;

public class Accelerator : MonoBehaviour {
    public float timeTillGreen = 2f;
    public GameObject background;
    public GameObject accelerometerNeedle;
    public Sprite backgroundLightOn;
	
	// Update is called once per frame
	void Update () {
        timeTillGreen -= Time.deltaTime;

        if (timeTillGreen <= 0f)
        {
            background.GetComponent<SpriteRenderer>().sprite = backgroundLightOn;
        }
	}

    void OnMouseStay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeTillGreen <= 0f)
            {
                accelerometerNeedle.transform.Rotate(new Vector3(0f,0f,0.15f));
                Debug.Log("Victory");
            }
            else
            {
                Debug.Log("Fail");
            }
        }
    }
}
