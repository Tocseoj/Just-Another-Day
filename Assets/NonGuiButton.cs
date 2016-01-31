using UnityEngine;
using System.Collections;

public class NonGuiButton : MonoBehaviour {

    public Player player;
    public string buttonType;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buttonType.Equals("Up"))
            {
                player.MoveUp();
            }
            else if (buttonType.Equals("Right"))
            {
                player.MoveRight();
            }
            else if (buttonType.Equals("Left"))
            {
                player.MoveLeft();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
