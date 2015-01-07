using UnityEngine;
using System.Collections;

public class SpikeWall : MonoBehaviour {

	public GameObject spikePrefab;
	public int size;
	public Color color;

	void Awake () {
		Vector3 step = Vector3.zero;
		step.x  = spikePrefab.GetComponent<SpriteRenderer>().bounds.max.x;
		step.x -= spikePrefab.GetComponent<SpriteRenderer>().bounds.min.x;
	
		for (int i = 0; i < size; i++) {
			GameObject spike = Instantiate(spikePrefab, 
										   transform.position + step * i + step / 2, 
										   transform.rotation) as GameObject;
			
			spike.GetComponent<SpriteRenderer>().color = color;
			spike.transform.position = RotatePointAroundPivot(spike.transform.position, 
															  transform.position, 
															  transform.rotation.eulerAngles);
		}
	}
	
	void OnDrawGizmos() {
		Vector3 step = Vector3.zero;
		step.x  = spikePrefab.GetComponent<SpriteRenderer>().bounds.max.x;
		step.x -= spikePrefab.GetComponent<SpriteRenderer>().bounds.min.x;
	
		for (int i = 0; i < size; i++) {
			Vector3 left  = transform.position + step * i;
			Vector3 right = transform.position + step * (1 + i);
			Vector3 tip   = left + new Vector3(step.x / 2, -step.x, 0.0f);
			
			left  = RotatePointAroundPivot(left,  transform.position, transform.rotation.eulerAngles);
			right = RotatePointAroundPivot(right, transform.position, transform.rotation.eulerAngles);
			tip   = RotatePointAroundPivot(tip,   transform.position, transform.rotation.eulerAngles);
			
			Gizmos.color = color;
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
