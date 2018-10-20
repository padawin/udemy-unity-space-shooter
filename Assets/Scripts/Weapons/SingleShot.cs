using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Gun {
	public override void fire() {
		_fire();
	}

	public override void stopFire() {
	}
}
