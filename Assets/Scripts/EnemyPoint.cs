using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
		// Make prefab in same position
		GameObject go = (GameObject)Instantiate (
			prefab,
			Vector3.zero,
			Quaternion.identity);

		// Set enemy object to child
		go.transform.SetParent(transform, false);
	}
	
	// When editing stage, show Gizmo in Scene
	void OnDrawGizmos() {
		// Set Offset to Gizmo's bottom meets ground
		Vector3 offset = new Vector3(0, 0.5f, 0);

		// Show ball
		Gizmos.color = new Color(1, 0, 0, 0.5f);
		Gizmos.DrawSphere (transform.position + offset, 0.5f);

		// Show prefab name's Icon
		if (prefab != null)
			Gizmos.DrawIcon (transform.position + offset, prefab.name, true);
	}
}
