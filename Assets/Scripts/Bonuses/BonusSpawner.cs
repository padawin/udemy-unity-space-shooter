using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour {
	[SerializeField] List<GameObject> bonuses;

	public void spawn (Vector3 position) {
		if (bonuses.Count == 0) {
			return;
		}

		int bonusIndex = Random.Range(0, bonuses.Count);
		Instantiate(bonuses[bonusIndex], position, Quaternion.identity);
	}
}
