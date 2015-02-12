using UnityEngine;
using System.Collections;

public class Menu_Start : MonoBehaviour {
	
	public GameObject fade;
	public float fadeTime;
	
	private bool fading;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)) {
			fade.SetActive(true);
			fading = true;
		}
		if(fading)
			fadeTime -= Time.deltaTime;
		if(fadeTime <= 0.0f)
			Application.LoadLevel("Game");
	}
}
