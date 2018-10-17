using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] int health = 100;

	public void hit(DamageDealer damageDealer) {
		health -= damageDealer.getDamages();
		if (health < 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		DamageDealer damageDealer = collider.GetComponent<DamageDealer>();
		if (damageDealer == null) {
			return;
		}

		hit(damageDealer);
		damageDealer.hit();
	}
}
