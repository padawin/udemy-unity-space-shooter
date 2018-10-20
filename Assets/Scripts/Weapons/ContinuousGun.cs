using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousGun : Gun {
	[SerializeField] float timeBetweenShots = 0.5f;

	private bool isFiring;

	IEnumerator Start() {
		WaitForSeconds delay = new WaitForSeconds(timeBetweenShots);

		while (true) {
			while (isFiring) {
				_fire();
				yield return delay;
			}

			yield return null; // <--- wait for the next frame
		}
	}

	public override void fire() {
		isFiring = true;
	}

	public override void stopFire() {
		isFiring = false;
	}
}
