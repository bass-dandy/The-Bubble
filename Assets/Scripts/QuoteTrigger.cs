using UnityEngine;
using System.Collections;

public class QuoteTrigger : MonoBehaviour {

	public GameObject panel;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			Instantiate(panel);
			Destroy(gameObject);
		}
	}
}
