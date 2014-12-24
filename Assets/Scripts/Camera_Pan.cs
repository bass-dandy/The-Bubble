using UnityEngine;
using System.Collections;

public class Camera_Pan : MonoBehaviour {

	public float panSpeed;
	public float drag;

	public Transform p1;
	public Transform p2;
	
	private Vector3 velocity;

	void Start() {
		velocity = Vector3.zero;
	}
	
	void Update() {
		transform.position += velocity * Time.deltaTime;
	}
	
	void PanUp() {
		velocity.y = panSpeed;
		StartCoroutine(Decelerate());
	}
	
	private IEnumerator Decelerate() {
		while(velocity.y > 0) {
			if(Mathf.Abs(velocity.y) > panSpeed / 2)
				velocity.y = Mathf.Lerp(velocity.y, 0.0f, Time.deltaTime * drag);
			else if (Mathf.Abs(velocity.y) > panSpeed / 8)
				velocity.y = Mathf.Lerp(velocity.y, 0.0f, Time.deltaTime * drag * 2);
			else
				velocity.y = 0;
			yield return null;
		}
	}
}
