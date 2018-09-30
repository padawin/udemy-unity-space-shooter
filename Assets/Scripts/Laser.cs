using UnityEngine;

public class Laser : MonoBehaviour {
	[SerializeField] float speed = 5f;

	// Use this for initialization
	void Start () {
		Vector2 velocity = new Vector2(0, speed);
		GetComponent<Rigidbody2D>().velocity = velocity;
	}
}
