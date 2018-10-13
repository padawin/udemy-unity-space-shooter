using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] float speed = 5f;

	public float getSpeed() {
		return speed * Time.deltaTime;
	}
}
