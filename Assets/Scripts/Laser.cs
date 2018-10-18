using UnityEngine;

public class Laser : MonoBehaviour {
	[SerializeField] float speed = 5f;

	public void setVelocity(Vector2 direction) {
		direction.Normalize();
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
