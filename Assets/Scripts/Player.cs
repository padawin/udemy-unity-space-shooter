using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float distanceFromCenter = 1f;
	[SerializeField] float speed = 10;

	float getDelta() {
		return Input.GetAxis("Horizontal") * Time.deltaTime * speed;
	}

	void tilt() {
		Quaternion newRotation = new Quaternion(
			transform.rotation.x,
			-getDelta() * Mathf.PI / 8,
			transform.rotation.z,
			transform.rotation.w
		);
		transform.rotation = newRotation;
	}

	void move () {
		var newPosX = Mathf.Clamp(
			transform.position.x + getDelta(),
			-distanceFromCenter,
			distanceFromCenter
		);
		Vector2 newPos = new Vector2(newPosX, transform.position.y);
		transform.position = newPos;
	}

	// Update is called once per frame
	void Update () {
		tilt();
		move();
	}
}
