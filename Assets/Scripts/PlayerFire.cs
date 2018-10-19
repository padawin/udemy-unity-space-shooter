using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {
	Gun gun;

	void Start() {
		gun = GetComponentInChildren<Gun>();
	}

	void fire() {
		if (Input.GetButtonDown("Fire1")) {
			gun.fire();
		}
		else if (Input.GetButtonUp("Fire1")) {
			gun.stopFire();
		}
	}

	// Update is called once per frame
	void Update () {
		fire();
	}
}
