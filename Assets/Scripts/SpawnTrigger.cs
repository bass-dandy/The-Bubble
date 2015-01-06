using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			other.GetComponent<Player_Movement>().spawn = transform;
		}
	}
}
