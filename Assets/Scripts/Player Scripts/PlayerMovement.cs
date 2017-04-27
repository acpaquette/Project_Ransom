using UnityEngine;
using System.Collections;

// Handles the physics of player movement
public class PlayerMovement : MonoBehaviour {
	public float xStart;
	public float yStart;

	private int speed;

	private Rigidbody2D rb;
	private Vector2 playerVelocity;

	private double xPrevious;
	private double yPrevious;
	private float magnitude;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		name = rb.name;
		GetComponent<Rigidbody2D>().position = new Vector2(xStart, yStart);
	}

	// Update is called every significant frame
  public void Update () {
		xPrevious = rb.position.x;
		yPrevious = rb.position.y;
		// Debug.Log(playerVelocity);
	}

	public void FixedUpdate () {
	}

	// Moves the player up by the ySpeed as a normalized physics vector
	// Needs to be edited
	// Current moves player at a stepper diagonal
	public void Move(string[] directions, int speed) {
		Vector2 vector = new Vector2(0, 0);
		foreach (string move in directions) {
			if (move == "Right") {
				vector.x += speed;
			}
			else if (move == "Left") {
				vector.x -= speed;
			}
			else if (move == "Up") {
				vector.y += speed;
			}
			else if (move == "Down") {
				vector.y -= speed;
			}
		}
		playerVelocity = speed * (vector.normalized);
		Debug.Log(playerVelocity);
		if (playerVelocity.x == 0 && playerVelocity.y == 0) {
			Debug.Log(rb.velocity);
			Vector2.Scale(rb.velocity, new Vector2(50f, 50f));
			Debug.Log(rb.velocity);
		}
		else {
			rb.velocity = playerVelocity;
		}
	}

	// Will immidiatly stop the players movement
	// Generally don't like this as a way to stop the player
	public void Stop () {
		rb.velocity = new Vector2(0, 0);
	}
}
