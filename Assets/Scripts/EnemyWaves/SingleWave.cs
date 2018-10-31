using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Single enemy wave config")]
public class SingleWave : WaveConfig {
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] GameObject path;
	[SerializeField] float timeBetweenSpawn = 0.5f;
	// Random delta to apply to time between spawn for not quite regular spawning
	[SerializeField] float spawnRandomFactor = 0.5f;
	[SerializeField] int numberOfEnemies = 5;
	[SerializeField] float enemiesSpeed = 5f;

	public override GameObject spawnEnemy() {
		var enemy = Instantiate(
			getEnemyPrefab(),
			getWaypoints()[0].transform.position,
			Quaternion.identity
		);
		enemy.GetComponent<EnemyPathFollower>().setWaveConfig(this);
		return enemy;
	}

	public override float getTimeBeforeNextEnemy() {
		return timeBetweenSpawn + Random.Range(-spawnRandomFactor, spawnRandomFactor);
	}

	public override int getNumberOfEnemies() {
		return numberOfEnemies;
	}

	public List<Transform> getWaypoints() {
		List<Transform> waypoints = new List<Transform>();
		foreach (Transform child in path.transform) {
			waypoints.Add(child);
		}
		return waypoints;
	}

	public float getEnemySpeed() {
		return enemiesSpeed * Time.deltaTime;
	}

	private GameObject getEnemyPrefab() {
		return enemyPrefab;
	}
}
