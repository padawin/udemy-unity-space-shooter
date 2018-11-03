using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireContinuous : MonoBehaviour {
	Player player;
	[SerializeField] List<Gun> guns;
	float timeToNextShot = 0;
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 1.5f;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		setTimeToNextShot();
	}

	bool isVisible() {
		Vector3 screenPoint = Camera.main.WorldToViewportPoint(
			transform.position
		);
		return (
			screenPoint.z > 0 &&
			screenPoint.x > 0 &&
			screenPoint.x < 1 &&
			screenPoint.y > 0 &&
			screenPoint.y < 1
		);
	}

	// Update is called once per frame
	void Update () {
		if (!player || !isVisible()) {
			return;
		}

		foreach (var gun in guns) {
			timeToNextShot -= Time.deltaTime;
			if (timeToNextShot <= 0f) {
				gun.fire();
				setTimeToNextShot();
			}
		}
	}

	void setTimeToNextShot() {
		timeToNextShot = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
}
