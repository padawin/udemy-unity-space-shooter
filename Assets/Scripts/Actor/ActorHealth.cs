using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorHealth : MonoBehaviour {
	[SerializeField] int health = 100;

	public void hit(DamageDealer damageDealer) {
		health -= damageDealer.getDamages();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		DamageDealer damageDealer = collider.GetComponent<DamageDealer>();
		if (damageDealer == null) {
			return;
		}

		hit(damageDealer);
		damageDealer.hit();
	}

	public int getHealth() {
		return health;
	}
}