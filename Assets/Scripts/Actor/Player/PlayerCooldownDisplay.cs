using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCooldownDisplay : MonoBehaviour {
	[SerializeField] PlayerCooldown cooldownToWatch;
	[SerializeField] Color coldColor;
	[SerializeField] Color hotColor;
	[SerializeField] Color overHeatColor;
	float maxSize;
	Image image;

	// Use this for initialization
	void Start () {
		maxSize = transform.localScale.x;
		image = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		float ratio = (float) cooldownToWatch.getCooldown() / (float) cooldownToWatch.getMaxCooldown();
		float size = ratio * maxSize;
		float width = Mathf.Min(Mathf.Max(0, size), maxSize);
		Vector2 newSize = new Vector2(width, transform.localScale.y);
		transform.localScale = newSize;
		if (ratio == 0.0f) {
			return;
		}
		float r, g, b;
		if (cooldownToWatch.isOverheating()) {
			r = overHeatColor.r;
			g = overHeatColor.g;
			b = overHeatColor.b;
		}
		else {
			// @TODO use lerp
			r = ratio * (hotColor.r - coldColor.r) + coldColor.r;
			g = ratio * (hotColor.g - coldColor.g) + coldColor.g;
			b = ratio * (hotColor.b - coldColor.b) + coldColor.b;
		}
		Color c = new Color(r, g, b, image.color.a);
		image.color = c;
	}
}
