using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameSession gameSession = FindObjectOfType<GameSession>();
		GetComponent<ActorHealth>().setMaxHealth(
			gameSession.getPlayerExtraHealth()
		);
		gameSession.loadScore();
	}
}
