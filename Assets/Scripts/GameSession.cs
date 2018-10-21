using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
	int gameScore = 0;

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

	public void addPoints(int points) {
		gameScore += points;
	}

	public int getScore() {
		return gameScore;
	}

	public void resetGame() {
		gameScore = 0;
	}
}
