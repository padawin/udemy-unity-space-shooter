using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float timeBetweenShots = 0.5f;
	[SerializeField] GameObject laserPrefab;

	Coroutine fireCoroutine;

	void fire() {
		if (Input.GetButtonDown("Fire1")) {
			fireCoroutine = StartCoroutine(fireContinuously());
		}
		else if (Input.GetButtonUp("Fire1")) {
			StopCoroutine(fireCoroutine);
		}
	}

	IEnumerator fireContinuously() {
		while (true) {
			Instantiate(laserPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(timeBetweenShots);
		}
	}

	// Update is called once per frame
	void Update () {
		fire();
	}
}
