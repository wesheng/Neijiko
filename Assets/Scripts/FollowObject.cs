using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Vector3 Offset;

	// Update is called once per frame
	void Update () {
	    if (ObjectToFollow)
	    {
	        transform.position = ObjectToFollow.position + Offset;

	    }
	}
}
