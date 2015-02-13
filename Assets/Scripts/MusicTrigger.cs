using UnityEngine;
using System.Collections;

public class MusicTrigger : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			SendMessageUpwards("Advance");
			Destroy(gameObject)	;
		}
	}
}
