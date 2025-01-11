using UnityEngine;
using UnityEngine.SceneManagement;


public class OnGameSceneLoaded : MonoBehaviour {

    private const string GameSceneName = "GameScene";

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name != GameSceneName) return;
        LevelManager.GetInstance().Score.reset();
        if (LevelManager.GetInstance().Level.achievement != null) {
            Social.ReportProgress(LevelManager.GetInstance().Level.achievement, 100.0f, (bool success) => {
                // handle success or failure
            });
        }
    }

}