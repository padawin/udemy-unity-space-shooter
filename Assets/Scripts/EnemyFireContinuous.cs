using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireContinuous : MonoBehaviour {
	Gun gun;

	// Use this for initialization
	void Start () {
		gun = GetComponentInChildren<Gun>();
	}
	
	// Update is called once per frame
	void Update () {
		gun.fire();
	}
}
