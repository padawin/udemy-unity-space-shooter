using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveConfig : ScriptableObject {
	[SerializeField] protected bool _waitUntilDefeated = false;
	[SerializeField] protected bool _destroyAtArrival = true;

	public abstract GameObject spawnEnemy();
	public abstract float getTimeBeforeNextEnemy();
	public abstract int getNumberOfEnemies();

	public bool waitUntilDefeated() {
		return _waitUntilDefeated;
	}

	public bool destroyAtArrival() {
		return _destroyAtArrival;
	}
}
