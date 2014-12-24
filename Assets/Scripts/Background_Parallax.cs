using UnityEngine;
using System.Collections;

public class Background_Parallax : MonoBehaviour {

	public Transform cameraPos;
	public Transform front;
	public Transform middle;
	public Transform back;
	
	public float frontOfs;
	public float middleOfs;
	public float backOfs;
	

	void Update () {
		front.position  = new Vector3(0.0f, cameraPos.position.y / 4 + frontOfs,front.position.z);
		middle.position = new Vector3(0.0f, cameraPos.position.y / 2 + middleOfs, middle.position.z);
		back.position   = new Vector3(0.0f, cameraPos.position.y + backOfs, back.position.z);
	}
}
