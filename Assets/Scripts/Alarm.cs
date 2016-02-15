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
			GameController.control.PlayerWon(2f);	// Victory Condition
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
}
