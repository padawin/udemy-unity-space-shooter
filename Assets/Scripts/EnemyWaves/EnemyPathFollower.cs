using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFollower : MonoBehaviour {
	int currentWayPoint = 0;

    WaveConfig waveConfig;

	public void setWaveConfig(WaveConfig waveConfig) {
		this.waveConfig = waveConfig;
	}

	public Transform getCurrentWayPoint() {
		return waveConfig.getWaypoints()[currentWayPoint];
	}

	public Transform getNextWayPoint() {
        List<Transform> waypoints = waveConfig.getWaypoints();
		if (currentWayPoint >= waypoints.Count - 1) {
			return null;
		}
		return waypoints[currentWayPoint + 1];
	}

	public void setNextWayPoint() {
		currentWayPoint++;
	}

	// Use this for initialization
	void Start () {
		placeOnPath();
	}
	
	// Update is called once per frame
	void Update () {
		var next = getNextWayPoint();
		if (next == null) {
			if (waveConfig.destroyAtArrival()) {
				Destroy(gameObject);
			}
			return;
		}

		transform.position = Vector2.MoveTowards(
			transform.position, next.position, waveConfig.getEnemySpeed()
		);

		if (next.position == transform.position) {
			setNextWayPoint();
		}
	}

	void placeOnPath() {
		transform.position = getCurrentWayPoint().position;
	}
}
