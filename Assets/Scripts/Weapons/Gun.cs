using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
	[SerializeField] GameObject laserPrefab;
	[SerializeField] Vector2 gunDirection;

	[SerializeField] AudioClip gunSound;
	[SerializeField][Range(0, 1)] float soundVolume = 1;

	PlayerCooldown cooldown;
	[SerializeField] int cooldownValue;

	protected void Start() {
		cooldown = GetComponent<PlayerCooldown>();
	}

	protected void _fire() {
		if (cooldown && cooldown.getCooldown() + cooldownValue > cooldown.getMaxCooldown()) {
			return;
		}

		if (gunSound) {
			AudioSource.PlayClipAtPoint(
				gunSound, Camera.main.transform.position, soundVolume
			);
		}
		Quaternion rotation = Quaternion.Euler(
			0, 0,
			Mathf.Atan2(gunDirection.y, gunDirection.x) * 180 / Mathf.PI
		);
		GameObject laser = Instantiate(laserPrefab, transform.position, rotation);
		laser.GetComponent<Ammo>().setVelocity(gunDirection);
		if (cooldown) {
			cooldown.increase(cooldownValue);
		}
	}

	public abstract void fire();
	public abstract void stopFire();
}
