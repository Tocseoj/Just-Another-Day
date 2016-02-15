using UnityEngine;
using System.Collections;

public class OverlayImage : MonoBehaviour {
    float nextScene = 0f;
    bool next = false;

    void Update()
    {

        if (next)
        {
            if (nextScene < Time.time - 1/*seconds*/)
            {
                GameController.control.score[GameController.control.day] += Timer.staticTimer.clock * 10;
                GameController.control.NextScene();
            }
        }

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // GameController.control.hidden[7] = true;
            Timer.staticTimer.StopClock();
            StartTimer();
            GameObject go = GameObject.Find("Check");
            go.GetComponent<SpriteRenderer>().enabled = true;
            go.GetComponent<AudioSource>().enabled = true;
        }
    }


    void StartTimer()
    {
        if (!next)
        {
            nextScene = Time.time;
            next = true;
        }
    }
}
