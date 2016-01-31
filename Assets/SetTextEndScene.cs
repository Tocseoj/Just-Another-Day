using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetTextEndScene : MonoBehaviour {

	public Text total;
	public Text chart;

	// Use this for initialization
	void Awake () {
		total.text = "Total Score: " + GameController.control.total;
		chart.text = "Day 1\tScore: " + GameController.control.score[0] +
		"\n\nDay 2\tScore: " + GameController.control.score[1] +
		"\n\nDay 3\tScore: " + GameController.control.score[2] +
		"\n\nDay 4\tScore: " + GameController.control.score[3] +
		"\n\nDay 5\tScore: " + GameController.control.score[4];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
