using UnityEngine;
using System.Collections;

public class OverlayImage : MonoBehaviour {

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
			GameController.control.PlayerWon(2f);	// Victory Condidtion
        }
    }
}
