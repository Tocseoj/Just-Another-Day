using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public float alarmGoingOff = 3f;
    public float clockTime = 0f;
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
        if (alarmGoingOff <= clockTime - 5f)
            GetComponent<Image>().sprite = states[1];
        else if (alarmGoingOff <= clockTime - 2f)
            GetComponent<Image>().sprite = states[0];
       
    }
}
