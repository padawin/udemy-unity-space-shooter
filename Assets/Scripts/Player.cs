using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float distanceFromCenter = 1f;
	void move () {
		var deltaX = Input.GetAxis("Horizontal");
		var newPosX = Mathf.Clamp(
			transform.position.x + deltaX,
			-distanceFromCenter,
			distanceFromCenter
		);
		Vector2 newPos = new Vector2(newPosX, transform.position.y);
		transform.position = newPos;
	}

	// Update is called once per frame
	void Update () {
		move();
	}
}
