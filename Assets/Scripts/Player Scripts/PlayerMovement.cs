using UnityEngine;
using System.Collections;

// Handles the physics of player movement
public class PlayerMovement : MonoBehaviour, IMovement {
	public float xStart;
	public float yStart;

	public float xSpeed;
	public float ySpeed;
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
	}

	public void FixedUpdate () {
	}

	// Moves the player up by the ySpeed as a normalized physics vector
	public void MoveUp () {
		Vector2 vector = rb.velocity;
		vector.y += ySpeed;
	  magnitude = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
		vector = ySpeed * (vector/magnitude);
		rb.velocity = vector;
	}

	// Moves the player down by the negation of the ySpeed as a normalized physics vector
	public void MoveDown () {
		Vector2 vector = rb.velocity;
		vector.y -= ySpeed;
		magnitude = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
		vector = ySpeed * (vector/magnitude);
		rb.velocity = vector;
	}

	// Moves the player to the right by the xSpeed as a normalized physics vector
	public void MoveRight () {
		Vector2 vector = rb.velocity;
		vector.x += xSpeed;
		magnitude = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
		vector = xSpeed * (vector/magnitude);
		rb.velocity = vector;
	}

	// Moves the player to the left by the negation of the xSpeed as a normalized physics vector
	public void MoveLeft () {
		Vector2 vector = rb.velocity;
		vector.x -= xSpeed;
		magnitude = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
		vector = xSpeed * (vector/magnitude);
		rb.velocity = vector;
	}

	// Will immidiatly stop the players movement
	// Generally don't like this as a way to stop the player
	public void Stop () {
		rb.velocity = new Vector2(0, 0);
	}
}
