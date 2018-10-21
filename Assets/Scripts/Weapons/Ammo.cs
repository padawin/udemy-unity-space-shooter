using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : MonoBehaviour {
	[SerializeField] protected float speed = 5f;

	public void setVelocity(Vector2 direction) {
		direction.Normalize();
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
