using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
	[SerializeField] int damages = 10;
	[SerializeField] GameObject explosion;

	public int getDamages() {
		return damages;
	}

	public void hit() {
		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
