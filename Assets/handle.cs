using UnityEngine;
using System.Collections;

public class handle : MonoBehaviour {

    public GameObject backgroundDoor;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            backgroundDoor.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
