using UnityEngine;
using System.Collections;

public class Snooze : MonoBehaviour {
    public bool shrinking;
    public bool rotateRight;

	// Update is called once per frame
	void Update () {
        if (transform.localScale.x <= 0.5f)
            shrinking = false;
        else if (transform.localScale.x >= 1f)
            shrinking = true;

        if (shrinking)
            transform.localScale = transform.localScale - Vector3.one * 0.02f;
        else
            transform.localScale = transform.localScale + Vector3.one * 0.02f;

        if (transform.rotation.z >= 0.15f)
            rotateRight = true;
        else if(transform.rotation.z <= -0.15f)
            rotateRight = false;

        if (rotateRight)
            transform.Rotate(0f,0f,-0.4f);
        else
            transform.Rotate(0f,0f,0.4f);
    }
}
