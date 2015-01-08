﻿using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public GameObject wallPrefabNormal;
	public GameObject wallPrefabBubble;
	public GameObject wallPrefabPlayer;

	public bool normal;
	public bool bubble;
	public bool p1;
	public bool p2;
	
	public Color normalColor;
	public Color bubbleColor;
	
	void Awake() {
		if(normal) {
			GameObject wall;
			wall = Instantiate(wallPrefabNormal, 
							   transform.position + new Vector3(0.0f, 0.0f, 15.0f), 
							   transform.rotation) as GameObject;
							   
			wall.GetComponent<SpriteRenderer>().color = normalColor;
			wall.transform.localScale = transform.localScale;
		}
		if(bubble) {
			GameObject wall;
			wall = Instantiate(wallPrefabBubble, 
							   transform.position + new Vector3(0.0f, 0.0f, -6.0f), 
							   transform.rotation) as GameObject;
							   
			wall.GetComponent<SpriteRenderer>().color = bubbleColor;
			wall.transform.localScale = transform.localScale;
		}
		if(p1) {
			GameObject wall;
			wall = Instantiate(wallPrefabPlayer, 
							   transform.position + new Vector3(0.0f, 0.0f, -8.0f), 
							   transform.rotation) as GameObject;
							   
			wall.transform.localScale = transform.localScale;
		}
		if(p2) {
			GameObject wall;
			wall = Instantiate(wallPrefabPlayer, 
							   transform.position + new Vector3(0.0f, 0.0f, -10.0f), 
							   transform.rotation) as GameObject;
							   
			wall.transform.localScale = transform.localScale;
		}
		Destroy (GetComponent<Wall>());
	}
	
	void OnDrawGizmos() {
		if(p1)
			Gizmos.color = Color.cyan;
		else if(p2)
			Gizmos.color = Color.magenta;
		else
			Gizmos.color = normalColor;
			
		Gizmos.DrawCube(transform.position, transform.localScale);
	}
}
