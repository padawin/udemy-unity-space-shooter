using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
	ActorHealth enemyHealth;
	[SerializeField] GameObject explosion;
	[SerializeField] int points = 0;
	[SerializeField][Range(0, 100)] int bonusProbability = 0;
	BonusSpawner bonusSpawner;
	GameSession gameSession;

	// Use this for initialization
	void Start () {
		bonusSpawner = FindObjectOfType<BonusSpawner>();
		gameSession = FindObjectOfType<GameSession>();
		enemyHealth = GetComponent<ActorHealth>();
	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth.getHealth() > 0) {
			return;
		}

		gameSession.addPoints(points);
		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
		bool spawnBonus = Random.Range(0, 100) < bonusProbability;
		if (spawnBonus) {
			bonusSpawner.spawn(transform.position);
		}
	}
}
