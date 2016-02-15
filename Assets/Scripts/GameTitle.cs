using UnityEngine;
using System.Collections;

public class GameTitle : MonoBehaviour {
    public float timeBeforeAltering = 0.6f;
    private SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

	void Update () {
        timeBeforeAltering -= Time.deltaTime;

        if (timeBeforeAltering <= 0f)
        {
            sr.enabled = !sr.enabled;
            timeBeforeAltering = 0.6f;
        }
	}
}
