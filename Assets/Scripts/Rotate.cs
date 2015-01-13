using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float degreesPerSec;
	private Vector3 rotation;
	
	void Start() {
		rotation = new Vector3(0.0f, 0.0f, degreesPerSec);
	}
	
	void Update() {
		transform.Rotate(rotation * Time.deltaTime);
	}
}
