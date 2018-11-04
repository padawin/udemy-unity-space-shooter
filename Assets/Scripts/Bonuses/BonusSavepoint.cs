using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSavepoint : Bonus {
	protected override void grantBonus() {
		GameSession gameSession = FindObjectOfType<GameSession>();
		EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
		ActorHealth playerHealth = FindObjectOfType<Player>().GetComponent<ActorHealth>();
		gameSession.setStartWaveIndex(enemySpawner.getCurrentWave());
		gameSession.setPlayerExtraHealth(playerHealth.getMaxHealthExtra());
		gameSession.saveScore();
	}
}
