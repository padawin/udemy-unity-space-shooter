using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	[SerializeField] SceneLoader sceneLoader;
	[SerializeField] GameObject explosion;
	[SerializeField] float timeBeforeGameOver = 5;
	ActorHealth playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = GetComponent<ActorHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.getHealth() > 0) {
			return;
		}

		Destroy(gameObject, timeBeforeGameOver);
		Instantiate(explosion, transform.position, transform.rotation);
		sceneLoader.loadSceneFromName("GameOver");
	}
}
