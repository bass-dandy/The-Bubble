using UnityEngine;
using System.Collections;

public class BoundaryGizmos : MonoBehaviour {

	public float bound;

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(new Vector3(bound, -5000, 0), new Vector3(bound, 5000, 0));
		Gizmos.DrawLine(new Vector3(-bound, -5000, 0), new Vector3(-bound, 5000, 0));
	}
}
