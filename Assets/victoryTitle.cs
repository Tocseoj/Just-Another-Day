using UnityEngine;
using System.Collections;

public class victoryTitle : MonoBehaviour {

    public int currentSprite = 0;
    public Sprite[] frames;
    private int changeEveryFrames;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (changeEveryFrames >= 15)
        {
            animate();
            changeEveryFrames = 0;
        }
        else
        {
            changeEveryFrames++;
        }
    }

    private void animate()
    {
        if (frames.Length <= 0)
            return;
        if (currentSprite < frames.Length)
        {
            sr.sprite = frames[currentSprite];
            currentSprite++;
        }
        else
        {
            currentSprite = 0;
            animate();
        }
    }
}
