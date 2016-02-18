using UnityEngine;
using System.Collections;

public class WaterDroplet : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -48f)
            Destroy(this.gameObject);
	}
}
