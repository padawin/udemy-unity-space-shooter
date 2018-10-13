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
		if (!path || !moveTowardsNextWayPoint()) {
			return;
		}

		if (pastWayPoint()) {
			setNextWayPoint();
		}
	}

	void placeOnPath() {
		if (!path) {
			return;
		}
		enemyObject = GetComponent<Enemy>();
		var waypoint = getCurrentWayPoint();
		Vector2 newPos = new Vector2(
			waypoint.transform.position.x, waypoint.transform.position.y
		);
		transform.position = newPos;
	}

	bool moveTowardsNextWayPoint() {
		var current = getCurrentWayPoint();
		var next = getNextWayPoint();

		if (next == null) {
			Destroy(gameObject);
			return false;
		}

		Vector2 direction = new Vector2(
			next.position.x - current.position.x,
			next.position.y - current.position.y
		);
		direction.Normalize();
		direction *= enemyObject.getSpeed();
		Vector2 newPos = new Vector2(
			transform.position.x + direction.x, transform.position.y + direction.y
		);
		transform.position = newPos;
		return true;
	}

	bool pastWayPoint() {
		Transform current = getCurrentWayPoint(),
			next = getNextWayPoint();

		float distFromCurrent = new Vector2(
			transform.position.x - current.position.x, transform.position.y - current.position.y
		).magnitude;
		float distWayPoints = new Vector2(
			next.position.x - current.position.x, next.position.y - current.position.y
		).magnitude;

		return distFromCurrent > distWayPoints;
	}
}
