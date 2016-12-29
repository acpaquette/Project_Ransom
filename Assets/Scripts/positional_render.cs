using UnityEngine;
using System.Collections;

public class positional_render : MonoBehaviour {
	private float player_position;
	private GameObject player;
	private float object_position;
	private SpriteRenderer current_object;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("player_character");
		current_object = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate () {
		player_position = player.GetComponent<Transform>().position.y;
		object_position = GetComponent<Transform>().position.y;
		if (player_position > object_position + .5) {
			current_object.sortingOrder = 1;
		}
		else if (player_position <= object_position + .5) {
			current_object.sortingOrder = 0;
		}
	}
}
