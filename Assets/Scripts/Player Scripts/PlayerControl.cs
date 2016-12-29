using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private PlayerMovement movement;
	private Rigidbody2D rb;
	public int speed;
	public bool canMove;

	// Use this for initialization
	void Start () {
		movement = GetComponent<PlayerMovement>();
		rb = GetComponent<Rigidbody2D>();
		canMove = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Jump")) {
			canMove = false;
			Debug.Log("Hahaha");
		}
		else {
			canMove = true;
		}
	}

	void FixedUpdate () {
		if (Input.GetButton("Right") && rb.velocity.x <= speed && canMove) {
			movement.MoveRight();
		}
		if (Input.GetButton("Left") && rb.velocity.x >= -speed && canMove) {
			movement.MoveLeft();
		}
		if (Input.GetButton("Up") && rb.velocity.y <= speed && canMove) {
			movement.MoveUp();
	  }
	  if (Input.GetButton("Down") && rb.velocity.y >= -speed && canMove) {
		  movement.MoveDown();
		}
  }
}
