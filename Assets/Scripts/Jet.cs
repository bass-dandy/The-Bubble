using UnityEngine;
using System.Collections;

public class Jet : MonoBehaviour {

	public float x;
	public float y;
	private Vector2 force;

	void Awake() {
		force = new Vector2(x, y);
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.tag == "Player") {
			other.GetComponent<Player_Movement>().Push(force);
		}
	}
}
