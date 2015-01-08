using UnityEngine;
using System.Collections;

public class SpikeWall : MonoBehaviour {

	public GameObject spikePrefabNormal;
	public GameObject spikePrefabBubble;
	public GameObject spikePrefabPlayer;
	
	public int size;
	
	public bool normal;
	public bool bubble;
	public bool p1;
	public bool p2;
	
	public Color normalColor;
	public Color bubbleColor;

	void Awake () {
		Vector3 step = Vector3.zero;
		step.x  = spikePrefabNormal.GetComponent<SpriteRenderer>().bounds.max.x;
		step.x -= spikePrefabNormal.GetComponent<SpriteRenderer>().bounds.min.x;
	
		for (int i = 0; i < size; i++) {
			if(normal) {
				GameObject spike = Instantiate(spikePrefabNormal, 
				                               transform.position + step * i + step / 2, 
				                               transform.rotation) as GameObject;
				
				spike.GetComponent<SpriteRenderer>().color = normalColor;
				spike.transform.position = RotatePointAroundPivot(spike.transform.position, 
				                                                  transform.position, 
				                                                  transform.rotation.eulerAngles);
				
				spike.transform.position += new Vector3(0.0f, 0.0f, 15.0f);
			}
			if(bubble) {
				GameObject spike = Instantiate(spikePrefabBubble, 
				                               transform.position + step * i + step / 2, 
				                               transform.rotation) as GameObject;
				
				spike.GetComponent<SpriteRenderer>().color = bubbleColor;
				spike.transform.position = RotatePointAroundPivot(spike.transform.position, 
				                                                  transform.position, 
				                                                  transform.rotation.eulerAngles);
				                                                  
				spike.transform.position += new Vector3(0.0f, 0.0f, -6.0f);
			}
			if(p1) {
				GameObject spike = Instantiate(spikePrefabPlayer, 
				                               transform.position + step * i + step / 2, 
				                               transform.rotation) as GameObject;
				
				spike.transform.position = RotatePointAroundPivot(spike.transform.position, 
				                                                  transform.position, 
				                                                  transform.rotation.eulerAngles);
				                                                  
				spike.transform.position += new Vector3(0.0f, 0.0f, -8.0f);
			}
			if(p2) {
				GameObject spike = Instantiate(spikePrefabPlayer, 
				                               transform.position + step * i + step / 2, 
				                               transform.rotation) as GameObject;
				
				spike.transform.position = RotatePointAroundPivot(spike.transform.position, 
				                                                  transform.position, 
				                                                  transform.rotation.eulerAngles);
				                                                  
				spike.transform.position += new Vector3(0.0f, 0.0f, -10.0f);
			}
		}
		Destroy (GetComponent<SpikeWall>());
	}
	
	void OnDrawGizmos() {
		// Get width of single spike
		Vector3 step = Vector3.zero;
		step.x  = spikePrefabNormal.GetComponent<SpriteRenderer>().bounds.max.x;
		step.x -= spikePrefabNormal.GetComponent<SpriteRenderer>().bounds.min.x;
	
		for (int i = 0; i < size; i++) {
			Vector3 left  = transform.position + step * i;
			Vector3 right = transform.position + step * (1 + i);
			Vector3 tip   = left + new Vector3(step.x / 2, -step.x, 0.0f);
			
			// Match parent rotation
			left  = RotatePointAroundPivot(left,  transform.position, transform.rotation.eulerAngles);
			right = RotatePointAroundPivot(right, transform.position, transform.rotation.eulerAngles);
			tip   = RotatePointAroundPivot(tip,   transform.position, transform.rotation.eulerAngles);
			
			// Choose editor color
			if(p1)
				Gizmos.color = Color.cyan;
			else if(p2)
				Gizmos.color = Color.magenta;
			else
				Gizmos.color = normalColor;
				
			// Draw in editor
			Gizmos.DrawLine(left, right);
			Gizmos.DrawLine(left,  tip);
			Gizmos.DrawLine(right, tip);
		}
	}
	
	private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angle) {
		Vector3 dir = point - pivot;
		dir = Quaternion.Euler(angle) * dir;
		point = dir + pivot;
		return point;
	}
}
