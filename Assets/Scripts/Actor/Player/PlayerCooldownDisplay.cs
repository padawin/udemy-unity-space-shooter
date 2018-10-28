using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCooldownDisplay : MonoBehaviour {
	[SerializeField] PlayerCooldown cooldownToWatch;
	float maxSize;

	// Use this for initialization
	void Start () {
		maxSize = transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
		float size = cooldownToWatch.getCooldown() * maxSize / cooldownToWatch.getMaxCooldown();
		float width = Mathf.Min(Mathf.Max(0, size), maxSize);
		Vector2 newSize = new Vector2(width, transform.localScale.y);
		transform.localScale = newSize;
	}
}
