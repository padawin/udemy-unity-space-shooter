using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireOnSight : MonoBehaviour {
	CircleCollider2D player;
	[SerializeField] List<Gun> guns;

	void Start() {
		PlayerMovement pm = FindObjectOfType<PlayerMovement>();
		if (pm) {
			player = FindObjectOfType<Player>().GetComponent<CircleCollider2D>();
		}
	}

	void Update() {
		if (!player) {
			return;
		}

		foreach (var gun in guns) {
			if (
				gun.transform.position.x > player.transform.position.x - player.radius
				&&
				gun.transform.position.x < player.transform.position.x + player.radius
			) {
				gun.fire();
			}
			else {
				gun.stopFire();
			}
		}
	}
}
