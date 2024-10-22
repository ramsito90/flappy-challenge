using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    private void Update() {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape)) {
            Exit();
        }
    }

    public void Awake() {
        if (instance == null) {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    private static void Exit() {
        Application.Quit();
    }

}