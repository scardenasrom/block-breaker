using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void LoadScene(string sceneName) {
        Block.breakableBricksCount = 0;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene() {
        Block.breakableBricksCount = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitRequest() {
        Application.Quit();
    }

    public void BlockDestroyed() {

    }

}
