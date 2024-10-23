using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    
    private void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;
    }

    private void Update() {
        if (Application.platform == RuntimePlatform.Android && UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame) {
            Exit();
        }
    }

    public void Awake() {
        if (_instance == null) {
            _instance = this;
        }

        Time.timeScale = 1f;
    }

    private static void Exit() {
        Application.Quit();
    }

}