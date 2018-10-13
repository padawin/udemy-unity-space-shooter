using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFollower : MonoBehaviour {
	int currentWayPoint = 0;

	List<Transform> waypoints;
	float speed;

	public void setWaypoints(List<Transform> theWaypoints) {
		waypoints = theWaypoints;
	}

	public void setSpeed(float theSpeed) {
		speed = theSpeed;
	}

	public Transform getCurrentWayPoint() {
		return waypoints[currentWayPoint];
	}

	public Transform getNextWayPoint() {
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
			Destroy(gameObject);
			return;
		}

		transform.position = Vector2.MoveTowards(
			transform.position, next.position, speed
		);

		if (next.position == transform.position) {
			setNextWayPoint();
		}
	}

	void placeOnPath() {
		transform.position = getCurrentWayPoint().position;
	}
}
