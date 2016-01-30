using UnityEngine;
using System.Collections;

public class CoffeePour : MonoBehaviour {

	public Transform splatterPrefab;

	Transform[] splatters = new Transform[20];
	int index = 0;
	bool full = false;
	int counter = 0;

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag.Equals("Coffee")) {
			Destroy(other.gameObject);
			counter++;
			if (counter >= 5) {
				counter = 0;
				if (full) {
					Destroy(splatters[index].gameObject);
				}
				splatters[index] = (Transform)Instantiate(splatterPrefab, other.transform.position, Quaternion.identity);
				index++;
				if (index >= 20) {
					full = true;
					index = 0;
				}
			}
		}
	}
}
