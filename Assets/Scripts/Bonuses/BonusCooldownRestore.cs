using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCooldownRestore : Bonus {
	protected override void grantBonus() {
		player.GetComponentInChildren<PlayerCooldown>().reset();
	}
}
