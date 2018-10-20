using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireContinuous : MonoBehaviour {
	Gun gun;
	float timeToNextShot = 0;
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 3f;
	

	// Use this for initialization
	void Start () {
		gun = GetComponentInChildren<Gun>();
	}
	
	// Update is called once per frame
	void Update () {
		timeToNextShot -= Time.deltaTime;
		if (timeToNextShot <= 0f) {
			gun.fire();
			timeToNextShot = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		}
	}
}
