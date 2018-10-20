using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
	ActorHealth enemyHealth;
	[SerializeField] GameObject explosion;

	// Use this for initialization
	void Start () {
		enemyHealth = GetComponent<ActorHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth.getHealth() > 0) {
			return;
		}

		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
