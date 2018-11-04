using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] List<WaveConfig> waveConfigs;
	int startWaveIndex = 0;
	int currentWaveIndex = 0;
	[SerializeField] bool looping = false;
	[SerializeField] SceneLoader sceneLoader;
	GameSession gameSession;

	// Use this for initialization
	IEnumerator Start () {
		gameSession = FindObjectOfType<GameSession>();
		startWaveIndex = gameSession.getStartWaveIndex();
		do {
			yield return StartCoroutine(spawnWaves());
		} while (looping);
		sceneLoader.loadNextScene();
	}

	IEnumerator spawnWaves() {
		for (
			currentWaveIndex = startWaveIndex;
			currentWaveIndex < waveConfigs.Count;
			currentWaveIndex++
		) {
			yield return StartCoroutine(
				spawnEnemies(waveConfigs[currentWaveIndex])
			);
		}
	}

	IEnumerator spawnEnemies(WaveConfig waveConfig) {
		List<GameObject> enemies = new List<GameObject>();
		for (
			int spawnedEnemies = 0;
			spawnedEnemies < waveConfig.getNumberOfEnemies();
			spawnedEnemies++
		) {
			yield return new WaitForSeconds(waveConfig.getTimeBeforeNextEnemy());
			enemies.Add(waveConfig.spawnEnemy());
		}
		if (waveConfig.waitUntilDefeated()) {
			yield return new WaitUntil(() => !enemies.Any(x => x != null));
		}
	}

	public void setStartWaveIndex(int waveIndex) {
		startWaveIndex = waveIndex;
	}

	public int getCurrentWave() {
		return currentWaveIndex;
	}
}
