using UnityEngine;
using System.Collections;

public class handle : MonoBehaviour {

    public GameObject backgroundDoor;
    public bool unlocked;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && unlocked)
        {
            backgroundDoor.SetActive(true);
        }
    }
}
