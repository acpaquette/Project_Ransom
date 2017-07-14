using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Handles the physics of player movement
public class Movement : MonoBehaviour, IMovement {
	public float xStart;
	public float yStart;

	private int speed;

	private Rigidbody2D rb;
	private Vector2 objectVelocity;

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
	public void Move(float?[] directions, int speed) {
		Vector2 vector = new Vector2(0, 0);
		foreach (float? move in directions) {
			if (move == null) {
				continue;
			}
			else {
				vector.x += Mathf.Cos((float)move);
				vector.y += Mathf.Sin((float)move);
			}
		}
		objectVelocity = speed * (vector.normalized);
		if (objectVelocity.x == 0f && objectVelocity.y == 0f) {
			rb.velocity = Vector2.Scale(rb.velocity, new Vector2(.99f, .99f));
		}
		else {
			rb.velocity = objectVelocity;
		}
	}

	// Will immidiatly stop the players movement
	// Generally don't like this as a way to stop the player
	public void Stop () {
		rb.velocity = new Vector2(0, 0);
	}
}
