using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCooldown : MonoBehaviour {
	[SerializeField] int cooldownRate = 1;
	[SerializeField] int maxCooldown = 100;
	[SerializeField] int cooldownOverhead = 150;
	[SerializeField] int cooldown;

	public void reset() {
		cooldown = 0;
	}

	public void increase(int val) {
		cooldown += val;
		if (cooldown >= maxCooldown) {
			cooldown = cooldownOverhead;
		}
	}

	public int getCooldown() {
		return cooldown;
	}

	public int getMaxCooldown() {
		return maxCooldown;
	}

	public bool isOverheating() {
		return cooldown > maxCooldown;
	}

	void Start() {
		reset();
	}

	void Update() {
		cooldown -= cooldownRate;
		if (cooldown < 0) {
			cooldown = 0;
		}
	}
}
