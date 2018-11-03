using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Group enemy wave config")]
public class GroupWave : WaveConfig {
	[SerializeField] List<WaveConfig> waves;
	int currentWave = 0;
	int spawnedEnemiesInWave = 0;

	public override GameObject spawnEnemy() {
		var enemy = waves[currentWave].spawnEnemy();
		spawnedEnemiesInWave++;
		if (spawnedEnemiesInWave == waves[currentWave].getNumberOfEnemies()) {
			spawnedEnemiesInWave = 0;
			currentWave = (currentWave + 1) % waves.Count;
		}
		return enemy;
	}

	public override float getTimeBeforeNextEnemy() {
		return waves[currentWave].getTimeBeforeNextEnemy();
	}

	public override int getNumberOfEnemies() {
		int number = 0;
		foreach (var wave in waves) {
			number += wave.getNumberOfEnemies();
		}
		return number;
	}
}
