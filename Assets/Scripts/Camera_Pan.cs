using UnityEngine;
using System.Collections;

public class Camera_Pan : MonoBehaviour {

	public float panSpeed;

	public Transform p1;
	public Transform p2;
	
	private float targetY;
	
	void Update() {
		if(!p2.GetComponent<Player_Movement>().isSpawned)
			targetY = p1.position.y;
		else
			targetY = (p1.position.y + p2.position.y) / 2;
			
		Vector3 next = transform.position;
		next.y = Mathf.Lerp(transform.position.y, targetY, panSpeed * Time.deltaTime);
		transform.position = next;
	}
}
