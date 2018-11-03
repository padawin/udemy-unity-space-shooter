using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealthRestore : Bonus {
	protected override void grantBonus() {
		player.GetComponent<ActorHealth>().restore();
	}
}
