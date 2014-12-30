using UnityEngine;
using System.Collections;

public class Camera_Trigger : MonoBehaviour {

	public GameObject mainCamera;

	void OnTriggerEnter2D(Collider2D other) {
		mainCamera.SendMessage("PanUp");
	}
}
