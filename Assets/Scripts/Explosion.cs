using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	[SerializeField] AudioClip explosionSound;
	[SerializeField][Range(0, 1)] float soundVolume = 1;

	void Start () {
		float animationDuration = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
		float soundDuration = 0;
		if (explosionSound) {
			soundDuration = explosionSound.length;
			AudioSource.PlayClipAtPoint(
				explosionSound, Camera.main.transform.position, soundVolume
			);
		}
		Destroy(
			gameObject,
			soundDuration > animationDuration ? soundDuration : animationDuration
		);
	}
}
