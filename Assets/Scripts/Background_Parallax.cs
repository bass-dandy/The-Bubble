using UnityEngine;
using System.Collections;

public class Background_Parallax : MonoBehaviour {

	public Transform cameraPos;
	public Transform front;
	public Transform middle;
	public Transform back;
	

	void Update () {
		front.position  = new Vector3(cameraPos.position.x / 4, cameraPos.position.y / 4,front.position.z);
		middle.position = new Vector3(cameraPos.position.x / 2, cameraPos.position.y / 2, middle.position.z);
		back.position   = new Vector3(cameraPos.position.x, cameraPos.position.y, back.position.z);
	}
}
