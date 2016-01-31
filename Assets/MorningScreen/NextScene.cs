using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextScene : MonoBehaviour {

	public Text date;
	public Text today;
	public Text total;

	public MorningScreen morningScreenScript;

	void Awake() {
		date.text = "Day: " + (GameController.control.day + 1);
		today.text = "Score Today: " + GameController.control.score[GameController.control.day];
		total.text = "Total: " + GameController.control.total;
	}

	public void Next() {
		if (morningScreenScript.GetComponent<Animator>().GetBool("Clicked") == false) {
			GameController.control.PlayMorningMusic();
			morningScreenScript.playSounds = 1;
			morningScreenScript.clockTime = 0f;
			morningScreenScript.playButton.color = new Color(1, 1, 1, 0);
			morningScreenScript.GetComponent<Animator>().SetBool("Clicked", true);
		} else {
			GameController.control.NextScene();
		}
	}
}
