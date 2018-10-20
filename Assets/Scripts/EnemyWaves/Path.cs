using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
	[SerializeField] List<Transform> waypoints;

	public Transform getWaypointAt(int index) {
		if (index < 0 || index >= waypoints.Count) {
			return null;
		}
		return waypoints[index];
	}
}
