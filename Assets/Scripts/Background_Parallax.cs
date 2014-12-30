using UnityEngine;
using System.Collections;

public class Background_Parallax : MonoBehaviour {

	public Transform cameraPos;
	public Transform middle;
	public Transform back;
	//public Transform back;
	
	public float middleOfs;
	public float backOfs;
	//public float backOfs;
	

	void Update () {
		middle.position  = new Vector3(0.0f, cameraPos.position.y / 4 + middleOfs,middle.position.z);
		back.position = new Vector3(0.0f, cameraPos.position.y / 2 + backOfs, back.position.z);
		//back.position   = new Vector3(0.0f, cameraPos.position.y + backOfs, back.position.z);
	}
}
