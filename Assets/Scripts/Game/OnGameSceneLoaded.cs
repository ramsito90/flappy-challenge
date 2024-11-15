using UnityEngine;
using UnityEngine.SceneManagement;


public class OnGameSceneLoaded : MonoBehaviour {

    private const string GameSceneName = "GameScene";

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name != GameSceneName) return;

        var level = JsonUtility.FromJson<Level>(LoadResourceTextfile("level1"));
        LevelManager.GetInstance().Score.reset();
        LevelManager.GetInstance().Level = level;
        Debug.Log("Loaded level: " + level);
    }

    private static string LoadResourceTextfile(string levelFileName) {
        return Resources.Load<TextAsset>("Levels/" + levelFileName).text;
    }

}