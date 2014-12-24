using UnityEngine;
using System.Collections;

public class Camera_Trigger : MonoBehaviour {

	public GameObject camera;

	void OnTriggerEnter2D(Collider2D other) {
		camera.SendMessage("PanUp");
	}
}
