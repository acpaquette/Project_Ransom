using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	private Movement playerMovement;
	private Rigidbody2D rb;
	private float?[] moves = new float?[4];
	public int speed;
	private int runSpeed;
	public bool canMove;

	// Use this for initialization
	void Start () {
		playerMovement = GetComponent<Movement>();
		rb = GetComponent<Rigidbody2D>();
		canMove = true;
		moves[0] = null;
		moves[1] = null;
		moves[2] = null;
		moves[3] = null;
	}

	// Update is called once per frame
	void Update () {
	}

	// FixedUpdate is called once per physics tick
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W) && canMove) {
			moves[0] = Mathf.PI/2;
		}
		else {
			moves[0] = null;
		}
		if (Input.GetKey(KeyCode.S) && canMove) {
			moves[1] = 3*Mathf.PI/2;
		}
		else {
			moves[1] = null;
		}
		if (Input.GetKey(KeyCode.A) && canMove) {
			moves[2] = Mathf.PI;
		}
		else {
			moves[2] = null;
		}
		if (Input.GetKey(KeyCode.D) && canMove) {
			moves[3] = 0;
		}
		else {
			moves[3] = null;
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			runSpeed = speed + speed/2;
			playerMovement.Move(moves, runSpeed);
		}
		else {
			playerMovement.Move(moves, speed);
		}
	}
}
