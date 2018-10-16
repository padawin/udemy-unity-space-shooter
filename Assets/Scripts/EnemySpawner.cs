using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] List<WaveConfig> waveConfigs;
	int currentWaveIndex = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies(waveConfigs[0]));
	}

	IEnumerator SpawnEnemies(WaveConfig waveConfig) {
		int numberOfEnemies = waveConfig.getNumberOfEnemies();
		for (int spawnedEnemies = 0; spawnedEnemies < numberOfEnemies; spawnedEnemies++) {
			var enemy = Instantiate(
				waveConfig.getEnemyPrefab(),
				waveConfig.getWaypoints()[0].transform.position,
				Quaternion.identity
			);
			enemy.GetComponent<EnemyPathFollower>().setWaveConfig(waveConfig);
			yield return new WaitForSeconds(waveConfig.getTimeBeforeNextEnemy());
		}
	}
}
