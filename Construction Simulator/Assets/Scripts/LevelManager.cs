using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public UIManager UIMngr;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void LevenEnd() {
        UIMngr.showLevelEndPanel();
    }

    // Menu
    public void StartGame() {
        SceneManager.LoadScene("Scene1");
    }

    public void SelectLevel(int level) {
        SceneManager.LoadScene("Scene" + level.ToString());
    }

    // In-Game
    public void RetryLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel() {
        int currentSceneIndx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Scene" + (currentSceneIndx + 1).ToString());
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
