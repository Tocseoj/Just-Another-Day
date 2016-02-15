using UnityEngine;
using System.Collections;

public class flipTitle : MonoBehaviour {

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

        if (sr.color.a > 0.5f)
            sr.color -= new Color(0,0,0,0.004f);
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