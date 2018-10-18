using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
	[SerializeField] GameObject laserPrefab;
	[SerializeField] Vector2 gunDirection;

	protected void _fire() {
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
		laser.GetComponent<Laser>().setVelocity(gunDirection);
	}

	public bool isFiring() {
		return false;
	}

	public abstract void fire();
	public abstract void stopFire();
}
