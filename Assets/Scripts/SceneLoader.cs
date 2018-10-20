using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {
	int lastLoadedSceneIndex = 1;

	private void _loadScene(int index) {
		lastLoadedSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index);
	}


	public void loadNextScene() {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		_loadScene(currentSceneIndex + 1);
	}

	public void loadLastLoadedScene() {
		_loadScene(lastLoadedSceneIndex);
	}

	public void loadFirstScene() {
		_loadScene(0);
	}

	public void loadScene(int index) {
		_loadScene(index);
	}

	public void loadSceneFromName(string name) {
		lastLoadedSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(name);
	}

	public void quit() {
		Application.Quit();
	}
}
