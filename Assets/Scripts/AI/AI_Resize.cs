using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Resize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float number = UnityEngine.Random.Range(0.25f, 2.0f);
        gameObject.transform.localScale = new Vector3(number, number, number);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 2.0f, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
