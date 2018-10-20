using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	// Use this for initialization

	void Start () {
		Destroy(
			gameObject,
			GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length
		);
	}
}
