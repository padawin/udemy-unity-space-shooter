using UnityEngine;

public class Missile : Ammo {
	[SerializeField] float angularSpeed = 0.5f;
	[SerializeField] GameObject explosion;
	Player player;
	Rigidbody2D rb;

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(gameObject);
		Instantiate(explosion, transform.position, transform.rotation);
	}

	void Start() {
		player = FindObjectOfType<Player>();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if (!player) {
			return;
		}

		Vector2 direction = player.transform.position - transform.position;
		direction.Normalize();
		float rotateAmount = Vector3.Cross(direction, transform.rotation.eulerAngles).z;
		rb.angularVelocity = rotateAmount * angularSpeed;
		rb.velocity = direction * speed;
		transform.rotation = Quaternion.Euler(
			0, 0,
			Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI
		);
	}
}
