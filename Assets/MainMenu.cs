using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public float alarmGoingOff = 3f;
    public float clockTime = 0f;
    public Image playButton;
    public bool highlight;
    public bool turningOn;
	public Sprite[] states;

    // Update is called once per frame
    void Update()
    {
        clockTime += Time.deltaTime;

        if (alarmGoingOff <= clockTime)
        {
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
		if (alarmGoingOff <= clockTime - 5f) {
			highlight = true;

			if (playButton.color.a >= 1)
				turningOn = false;
			else if (playButton.color.a <= 0)
				turningOn = true;
			if (turningOn)
				playButton.color += new Color(0, 0, 0, 0.01f);
			else
				playButton.color -= new Color(0, 0, 0, 0.01f);
		} else if (alarmGoingOff <= clockTime - 2f) {
			GetComponent<Image>().sprite = states[0];
		}
    }
}
