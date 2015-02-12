using UnityEngine;
using System.Collections;

public class Menu_Start : MonoBehaviour {
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevel("Game");
	}
}
