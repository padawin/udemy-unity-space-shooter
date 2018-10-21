using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour {
	[SerializeField] ActorHealth heathToWatch;
	float maxSize;

	// Use this for initialization
	void Start () {
		maxSize = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		float width = Mathf.Max(
			0,
			heathToWatch.getHealth() * maxSize / heathToWatch.getMaxHealth()
			);
		Vector2 newSize = new Vector2(width, transform.localScale.y);
		transform.localScale = newSize;
	}
}
