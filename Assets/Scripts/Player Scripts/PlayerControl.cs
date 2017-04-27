using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private PlayerMovement movement;
	private Rigidbody2D rb;
	private string[] moves = new string[4];
	public int speed;
	private int runSpeed;
	public bool canMove;

	// Use this for initialization
	void Start () {
		movement = GetComponent<PlayerMovement>();
		rb = GetComponent<Rigidbody2D>();
		canMove = true;
	}

	// Update is called once per frame
	void Update () {
	}

	// FixedUpdate is called once per physics tick
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W) && canMove) {
			moves[0] = "Up";
		}
		else {
			moves[0] = null;
		}
		if (Input.GetKey(KeyCode.S) && canMove) {
			moves[1] = "Down";
		}
		else {
			moves[1] = null;
		}
		if (Input.GetKey(KeyCode.A) && canMove) {
			moves[2] = "Left";
		}
		else {
			moves[2] = null;
		}
		if (Input.GetKey(KeyCode.D) && canMove) {
			moves[3] = "Right";
		}
		else {
			moves[3] = null;
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			runSpeed = speed + speed/2;
			movement.Move(moves, runSpeed);
		}
		else {
			movement.Move(moves, speed);
		}
	}
}
