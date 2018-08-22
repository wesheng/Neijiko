using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NejikoController : MonoBehaviour {
	const int MinLane = -2;
	const int MaxLane = 2;
	const float LaneWidth = 1.0f;
	const int DefaultLife = 3;
	const float StunDuration = 0.5f;

    public void AddEffect<T>(T effect) where T : EffectBase
    {
        StartCoroutine(effect.EffectCoroutine(this));
    }

    CharacterController controller;
	Animator animator;

	Vector3 moveDirection = Vector3.zero;
	int targetLane;
	private int life = DefaultLife;
    public int Life
    {
        get { return life; }
        set { life = value; }
    }
	float recoverTime = 0.0f;

	[SerializeField] public float gravity;
	[SerializeField] public float speedZ;
	[SerializeField] public float speedX;
	[SerializeField] public float speedJump;
	[SerializeField] public float stunAccelerationZ;
    [SerializeField] public float velocityZ;
    [SerializeField] private EffectInvincible invincibilityEffect;


    public ParticleSystem OnCollideParticles;
    public ParticleSystem RunningParticles;

    public CameraShake cameraShake;
    private AudioPlayer audioPlayer;

	public bool IsStunned() {
		return recoverTime > 0.0f || life <= 0;
	}

	// Use this for initialization
	void Start () {
        // Automatic retrieval of required components
        controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator> ();
	    audioPlayer = GetComponent<AudioPlayer>();
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
		    if (RunningParticles.isStopped && controller.isGrounded)
		    {
                RunningParticles.Play();
		    }
		    speedZ += velocityZ * Time.deltaTime;
		    // Slowly accelerate toward Z, used after being stunned
			float acceleratedZ = moveDirection.z + (stunAccelerationZ * Time.deltaTime);
			moveDirection.z = Mathf.Min(acceleratedZ, speedZ);

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
	    if (controller.isGrounded)
	    {
	        if (RunningParticles.isStopped)
	        {
	            RunningParticles.Play();
	        }
	        moveDirection.y = 0;
	    }

        // If the speed is more than 0, the running flag is set to true.
        animator.SetBool("run", moveDirection.z > 0.0f);
    }

	// Start moving to Left Lane
	public void MoveToLeft() {
		if (IsStunned ())
			return;
		if (controller.isGrounded && targetLane > MinLane)
        {
            targetLane -= 1;
        }
    }

	// Start moving to Right Lane
	public void MoveToRight() {
		if (IsStunned ())
			return;
		if (controller.isGrounded && targetLane < MaxLane)
			targetLane += 1;
	}

	public void Jump() {
		if (IsStunned ())
			return;
	    if (controller.isGrounded)
	    {
	        moveDirection.y = speedJump * 2f;
	        // Set Jumper trigger
	        animator.SetTrigger("jump");
	        RunningParticles.Stop();
	        audioPlayer.PlayClip("Jump");
	    }
	}

	// When generated crash to CharacterController
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (IsStunned ())
			return;

		if (hit.gameObject.CompareTag("Robo") && hit.controller.detectCollisions) {
			// Reduce life value, and change state to sleep
			life --;
			recoverTime = StunDuration;

		    Instantiate(OnCollideParticles, transform.position, Quaternion.identity);

			// Set Damage Trigger
			animator.SetTrigger("damage");
		    RunningParticles.Stop();
            AddEffect(invincibilityEffect);

		    audioPlayer.PlayClip("Hurt");
			// Delete colliding object
		    Destroy(hit.gameObject);
		    cameraShake.Shake(StunDuration);
		}
	}
}
