using UnityEngine;
using System.Collections;

public class Player_SpawnTrigger : MonoBehaviour {

	public GameObject Player;
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player")
			Player.SendMessage("Spawn");
	}
}
