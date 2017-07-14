using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	private Movement playerMovement;
	private float?[] moves = new float?[4];
  private GameObject player;
  private Transform playerTransform;
  private float power = 0.0f;
	public int arrowCount = 0;
	private bool canFire = true;
	public int speed;
	private int runSpeed;
	public bool canMove;

	// Use this for initialization
	void Start () {
		playerMovement = GetComponent<Movement>();
		canMove = true;
		moves[0] = null;
		moves[1] = null;
		moves[2] = null;
		moves[3] = null;
	}

	// Update is called once per frame
	void Update () {
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
    if (Input.GetKey(KeyCode.J)) {
      if (power < 50f) {
        Debug.Log(power);
        power += .5f;
      }
    }
		if (Input.GetKeyUp(KeyCode.J) && arrowCount > 0 && canFire) {
			StartCoroutine(shootArrow());
		}
		// while (Input.GetKey(KeyCode.Space)) {
		// 	float?[] jumpBack = new float?[1];
		// 	jumpBack[0] = Mathf.PI;
		// 	playerMovement.Move(jumpBack, 20);
		// 	canMove = false;
		// }
		if (Input.GetKey(KeyCode.LeftShift)) {
			runSpeed = speed + speed/2;
			playerMovement.Move(moves, runSpeed);
		}
		else {
			playerMovement.Move(moves, speed);
		}
	}

	IEnumerator shootArrow() {
		player = GameObject.Find("player_character");
		playerTransform = player.GetComponent(typeof(Transform)) as Transform;
		// Debug.Log(playerTransform.position);
		GameObject shot = (GameObject) Instantiate(Resources.Load("Shot"),
																							 new Vector3(playerTransform.position[0] + 0.5f,
																													 playerTransform.position[1], 0),
																							 Quaternion.identity);
		Rigidbody2D shotRb = shot.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		shotRb.velocity = new Vector2(2, 1) * power;
		power = 0.0f;
		arrowCount -= 1;
		canFire = false;
		yield return new WaitForSeconds(.5f);
		canFire = true;
	}

	// FixedUpdate is called once per physics tick
	void FixedUpdate () {
	}
}
