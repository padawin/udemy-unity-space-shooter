using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireContinuous : MonoBehaviour {
	Player player;
	Gun gun;
	Renderer myRenderer;
	float timeToNextShot = 0;
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 1.5f;


	// Use this for initialization
	void Start () {
		gun = GetComponentInChildren<Gun>();
		player = FindObjectOfType<Player>();
		myRenderer = GetComponent<Renderer>();
		setTimeToNextShot();
	}

	// Update is called once per frame
	void Update () {
		if (!player || !myRenderer.isVisible) {
			return;
		}

		timeToNextShot -= Time.deltaTime;
		if (timeToNextShot <= 0f) {
			gun.fire();
			setTimeToNextShot();
		}
	}

	void setTimeToNextShot() {
		timeToNextShot = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
}
