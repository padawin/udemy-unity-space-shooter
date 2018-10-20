using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	[SerializeField] AudioClip deathSound;
	[SerializeField][Range(0, 1)] float soundVolume = 1;

	void Start () {
		var animationDuration = GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
		var soundDuration = deathSound.length;
		AudioSource.PlayClipAtPoint(
			deathSound, Camera.main.transform.position, soundVolume
		);
		Destroy(
			gameObject,
			soundDuration > animationDuration ? soundDuration : animationDuration
		);
	}
}
