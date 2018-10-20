using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireOnSight : MonoBehaviour {
	CircleCollider2D player;
	Gun gun;

	void Start() {
		player = FindObjectOfType<PlayerMovement>().GetComponent<CircleCollider2D>();
		gun = GetComponentInChildren<Gun>();
	}

	void Update() {
		if (
			transform.position.x > player.transform.position.x - player.radius
			&&
			transform.position.x < player.transform.position.x + player.radius
		) {
			gun.fire();
		}
		else {
			gun.stopFire();
		}
	}
}