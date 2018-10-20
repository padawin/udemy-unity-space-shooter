using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] List<WaveConfig> waveConfigs;
	int startWaveIndex = 0;
	[SerializeField] bool looping = false;

	// Use this for initialization
	IEnumerator Start () {
		do {
			yield return StartCoroutine(spawnWaves());
		} while (looping);
	}

	IEnumerator spawnWaves() {
		for (int waveIndex = startWaveIndex; waveIndex < waveConfigs.Count; waveIndex++) {
			yield return StartCoroutine(spawnEnemies(waveConfigs[waveIndex]));
        }
    }

	IEnumerator spawnEnemies(WaveConfig waveConfig) {
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