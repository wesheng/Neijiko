using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp_Base : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	}

    public abstract void OnCollisionEnter(Collision hit);
    public abstract void GiveEffect(NejikoController controller);
}
