using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject {
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] GameObject path;
	[SerializeField] float timeBetweenSpawn = 0.5f;
	// Random delta to apply to time between spawn for not quite regular spawning
	[SerializeField] float spawnRandomFactor = 0.3f;
	[SerializeField] int numberOfEnemies = 5;
	[SerializeField] float enemiesSpeed = 5f;

	public List<Transform> getWayPoints() {
		List<Transform> waypoints = new List<Transform>();
		foreach (Transform child in path.transform) {
			waypoints.Add(child);
		}
		return waypoints;
	}

	public float getEnemySpeed() {
		return enemiesSpeed * Time.deltaTime;
	}
}
