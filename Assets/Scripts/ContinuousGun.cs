using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousGun : Gun {
	[SerializeField] float timeBetweenShots = 0.5f;
	Coroutine fireCoroutine;

	public bool isFiring() {
		return fireCoroutine != null;
	}

	public override void fire() {
		fireCoroutine = StartCoroutine(fireContinuously());
	}

	public IEnumerator fireContinuously() {
		while (true) {
			_fire();
			yield return new WaitForSeconds(timeBetweenShots);
		}
	}

	public override void stopFire() {
		StopCoroutine(fireCoroutine);
	}
}
