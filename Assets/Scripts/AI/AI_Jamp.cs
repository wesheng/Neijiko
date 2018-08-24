using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Jamp : MonoBehaviour {
    
    private float interval;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = UnityEngine.Random.Range(0.5f, 2.5f);
        interval = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

		if(timer <= 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 10.0f, 0.0f);
            timer = interval;
        }
	}
}
