using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour {
	[SerializeField] float speed = 1f;
	protected Player player;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * speed;
		player = FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		grantBonus();
		Destroy(gameObject);
	}

	protected abstract void grantBonus();
}
