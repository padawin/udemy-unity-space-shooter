using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFollower : MonoBehaviour {
	[SerializeField] Path path;
	int currentWayPoint = 0;

	Enemy enemyObject;

	public Transform getCurrentWayPoint() {
		return path.getWaypointAt(currentWayPoint);
	}

	public Transform getNextWayPoint() {
		return path.getWaypointAt(currentWayPoint + 1);
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
		if (!path) {
			return;
		}

		enemyObject = GetComponent<Enemy>();
		var next = getNextWayPoint();
		if (next == null) {
			Destroy(gameObject);
			return;
		}

		transform.position = Vector2.MoveTowards(
			transform.position, next.position, enemyObject.getSpeed()
		);

		if (next.position == transform.position) {
			setNextWayPoint();
		}
	}

	void placeOnPath() {
		if (!path) {
			return;
		}
		transform.position = getCurrentWayPoint().position;
	}
}
