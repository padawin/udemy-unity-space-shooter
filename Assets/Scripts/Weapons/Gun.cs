using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
	[SerializeField] GameObject laserPrefab;
	[SerializeField] Vector2 gunDirection;

	AudioSource audioSource;

	protected void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	protected void _fire() {
		if (audioSource) {
			audioSource.PlayOneShot(audioSource.clip);
		}
		Quaternion rotation = Quaternion.identity;
		rotation.z = Mathf.Acos(gunDirection.y) * 180 / Mathf.PI;
		GameObject laser = Instantiate(laserPrefab, transform.position, rotation);
		laser.GetComponent<Laser>().setVelocity(gunDirection);
	}

	public abstract void fire();
	public abstract void stopFire();
}
