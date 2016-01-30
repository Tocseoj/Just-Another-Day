using UnityEngine;
using System.Collections;

public class PencilBoxer : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {

		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			animator.SetBool ("is_punching", true);
		}
	}
}
