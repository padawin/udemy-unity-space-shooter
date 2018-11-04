using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
	int gameScore = 0;
	int gameScoreSaved = 0;
	int startWaveIndex = 0;
	int playerMaxHealthExtra = 0;

	// Use this for initialization
	void Awake () {
		SetUpSingleton();
	}

	private void SetUpSingleton() {
		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
		}
	}

	public void saveScore() {
		gameScoreSaved = gameScore;
	}

	public void loadScore() {
		gameScore = gameScoreSaved;
	}

	public void addPoints(int points) {
		gameScore += points;
	}

	public int getScore() {
		return gameScore;
	}

	public void resetGame() {
		gameScore = 0;
		gameScoreSaved = 0;
		playerMaxHealthExtra = 0;
		startWaveIndex = 0;
	}

	public void setPlayerExtraHealth(int maxHealthExtra) {
		playerMaxHealthExtra = maxHealthExtra;
	}

	public int getPlayerExtraHealth() {
		return playerMaxHealthExtra;
	}

	public void setStartWaveIndex(int waveIndex) {
		startWaveIndex = waveIndex;
	}

	public int getStartWaveIndex() {
		return startWaveIndex;
	}
}
