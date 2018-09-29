using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float speed = 10;

	float xMin;
	float xMax;

	void Start() {
		setWorldBoundaries();
	}

	private void setWorldBoundaries() {
		Camera mainCamera = Camera.main;
		float leftBoundary = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).x;
		float rightBoundary = mainCamera.ViewportToWorldPoint(new Vector2(1, 0)).x;
		xMin = leftBoundary + transform.localScale.x / 2;
		xMax = rightBoundary - transform.localScale.x / 2;
	}

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
		var newPosX = Mathf.Clamp(transform.position.x + getDelta(), xMin, xMax);
		Vector2 newPos = new Vector2(newPosX, transform.position.y);
		transform.position = newPos;
	}

	// Update is called once per frame
	void Update () {
		tilt();
		move();
	}
}
