using UnityEngine;
using System.Collections;

public class Camera_Movement : MonoBehaviour {

	public float panSpeed;

	public Transform p1;
	public Transform p2;

	
	void Update () {
		// Move camera to keep player one onscreen
		if(p1.position.x > transform.position.x + camera.orthographicSize) {
			if(p2.position.x > transform.position.x - camera.orthographicSize)
				camera.transform.position = new Vector3(transform.position.x + panSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		else if(p1.position.x < transform.position.x - camera.orthographicSize) {
			if(p2.position.x < transform.position.x + camera.orthographicSize)
				camera.transform.position = new Vector3(transform.position.x - panSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		// Move camera to keep player two onscreen
		else if(p2.position.x > transform.position.x + camera.orthographicSize) {
			if(p1.position.x > transform.position.x - camera.orthographicSize)
				camera.transform.position = new Vector3(transform.position.x + panSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		else if(p2.position.x < transform.position.x - camera.orthographicSize) {
			if(p1.position.x < transform.position.x + camera.orthographicSize)
				camera.transform.position = new Vector3(transform.position.x - panSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}
	}
}
