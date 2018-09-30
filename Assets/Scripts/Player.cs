using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float coolDownSpeed = 200f;
	[SerializeField] float speed = 10f;
	[SerializeField] GameObject laserPrefab;

	float xMin;
	float xMax;

	[SerializeField] float coolDownRatio = 0;

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
			-getDelta() * Mathf.PI / 2.5f,
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

	void fire() {
		if (Input.GetButtonDown("Fire1")) {
			if (coolDownRatio <= 0) {
				Instantiate(laserPrefab, transform.position, Quaternion.identity);
				coolDownRatio = 1090;
			}
		}

		if (coolDownRatio > 0) {
			coolDownRatio -= coolDownSpeed;
		}
	}

	// Update is called once per frame
	void Update () {
		tilt();
		move();
		fire();
	}
}
