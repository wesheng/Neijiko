﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour {
	const int MinLane = -2;
	const int MaxLane = 2;
	const float LaneWidth = 1.0f;
	const int DefaultLife = 3;
	const float StunDuration = 0.5f;

	CharacterController controller;
	Animator animator;

	Vector3 moveDirection = Vector3.zero;
	int targetLane;
	int life = DefaultLife;
	float recoverTime = 0.0f;

	public float gravity;
	public float speedZ;
	public float speedX;
	public float speedJump;
	public float accelerationZ;

	public int Life() {
		return life;
	}

	public bool IsStunned() {
		return recoverTime > 0.0f || life <= 0;
	}

	// Use this for initialization
	void Start () {
        // Automatic retrieval of required components
        controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// For debug
		if (Input.GetKeyDown("left")) MoveToLeft();
		if (Input.GetKeyDown("right")) MoveToRight();
		if (Input.GetKeyDown("space")) Jump();

		if (IsStunned ()) {
			// When sleep state, proceed recovery count
			moveDirection.x = 0.0f;
			moveDirection.z = 0.0f;
			recoverTime -= Time.deltaTime;
		} else {

			// Slowly accelerate toward Z
			float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
			moveDirection.z = Mathf.Clamp (acceleratedZ, 0, speedZ);

			// Calculate X direction movement
			float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
			moveDirection.x = ratioX * speedX;
		}

        // Adds as much force as gravity to every frame
        moveDirection.y -= gravity * Time.deltaTime;

        // Move Run
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
		controller.Move (globalDirection * Time.deltaTime);

        // If the motor is grounded after movement, the speed in the Y direction is reset
        if ( controller.isGrounded) moveDirection.y = 0;

        // If the speed is more than 0, the running flag is set to true.
        animator.SetBool("run", moveDirection.z > 0.0f);
	}

	// Start moving to Left Lane
	public void MoveToLeft() {
		if (IsStunned ())
			return;
		if (controller.isGrounded && targetLane > MinLane - 2)
			targetLane-=2;
	}

	// Start moving to Right Lane
	public void MoveToRight() {
		if (IsStunned ())
			return;
		if (controller.isGrounded && targetLane < MaxLane + 2)
			targetLane+=2;
	}

	public void Jump() {
		if (IsStunned ())
			return;
		moveDirection.y = speedJump * 2f;
		// Set Jumper trigger
		animator.SetTrigger("jump");
	}

	// When generated crash to CharacterController
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (IsStunned ())
			return;

		if (hit.gameObject.tag == "Robo") {
			// Reduce life value, and change state to sleep
			life --;
			recoverTime = StunDuration;

			// Set Damage Trigger
			animator.SetTrigger("damage");

			// Delete colliding object
			Destroy(hit.gameObject);
		}
	}

}
