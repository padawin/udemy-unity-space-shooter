using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealthIncrease : Bonus {
	[SerializeField] int extra = 100;

	protected override void grantBonus() {
		player.GetComponent<ActorHealth>().increaseHealth(extra);
		player.GetComponent<ActorHealth>().increaseMaxHealth(extra);
	}
}
