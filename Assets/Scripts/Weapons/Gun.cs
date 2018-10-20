using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
	[SerializeField] GameObject laserPrefab;
	[SerializeField] Vector2 gunDirection;

	[SerializeField] AudioClip gunSound;
	[SerializeField][Range(0, 1)] float soundVolume = 1;

	protected void _fire() {
		if (gunSound) {
			AudioSource.PlayClipAtPoint(
				gunSound, Camera.main.transform.position, soundVolume
			);
		}
		Quaternion rotation = Quaternion.identity;
		rotation.z = Mathf.Acos(gunDirection.y) * 180 / Mathf.PI;
		GameObject laser = Instantiate(laserPrefab, transform.position, rotation);
		laser.GetComponent<Laser>().setVelocity(gunDirection);
	}

	public abstract void fire();
	public abstract void stopFire();
}
