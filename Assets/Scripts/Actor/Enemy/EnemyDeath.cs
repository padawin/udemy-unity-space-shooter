using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
	ActorHealth enemyHealth;
	[SerializeField] GameObject explosion;
	[SerializeField] int points = 0;

	// Use this for initialization
	void Start () {
		enemyHealth = GetComponent<ActorHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth.getHealth() > 0) {
			return;
		}

		FindObjectOfType<GameSession>().addPoints(points);
		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
