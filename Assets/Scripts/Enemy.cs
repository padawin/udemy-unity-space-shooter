using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] float speed = 0.009f;

	public float getSpeed() {
		return speed;
	}
}
