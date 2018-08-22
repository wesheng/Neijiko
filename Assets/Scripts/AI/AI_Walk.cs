using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Walk : MonoBehaviour {
    
    [SerializeField] [Range(1.0f, 10.0f)] float m_speed = 1.0f;
    [HideInInspector] public Animator m_animator = null;

    [SerializeField] Vector3 waypointOffsetLeft     = new Vector3(-2.0f, 0.0f, 0.0f);
    [SerializeField] Vector3 waypointOffsetRight    = new Vector3(+2.0f, 0.0f, 0.0f);
    Vector3 currWaypoint;
    
    // Use this for initialization
    void Start ()
    {
        waypointOffsetLeft.y = transform.position.y;
        waypointOffsetRight.y = transform.position.y;
        waypointOffsetLeft.z = transform.position.z;
        waypointOffsetRight.z = transform.position.z;

        currWaypoint = waypointOffsetLeft;
        m_animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 velocity = Vector3.zero;
        Vector3 direction = Vector3.zero;
        
        direction = currWaypoint - transform.position;
        velocity.z = m_speed;

        bool isWalking = !Mathf.Approximately(velocity.magnitude, 0.0f);
        m_animator.SetBool("walk", isWalking);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), Time.deltaTime);

        velocity = transform.rotation * velocity;
        transform.position = transform.position + (velocity * Time.deltaTime);
        
        if(transform.position.x < waypointOffsetLeft.x)
        {
            currWaypoint = waypointOffsetRight;
        }
        else if (transform.position.x > waypointOffsetRight.x)
        {
            currWaypoint = waypointOffsetLeft;
        }
    }
}
