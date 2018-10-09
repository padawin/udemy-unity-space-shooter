using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D collider) {
		Destroy(collider.gameObject);
	}
}
