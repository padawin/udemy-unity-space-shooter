using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {
	GameSession gameSession;
	TextMeshProUGUI scoreField;

	// Use this for initialization
	void Start () {
		gameSession = FindObjectOfType<GameSession>();
		scoreField = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreField) {
			scoreField.text = gameSession.getScore().ToString();
		}
	}
}
