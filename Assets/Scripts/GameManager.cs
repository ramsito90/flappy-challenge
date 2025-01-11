using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    
    private void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;

        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private static void ProcessAuthentication(SignInStatus status) {
        if (status == SignInStatus.Success) {
            Social.ReportProgress("CgkI9eiF6tEXEAIQAw", 100.0f, (bool success) => {
                // handle success or failure
            });
            // Continue with Play Games Services
        } else {
            // Disable your integration with Play Games Services or show a login button
            // to ask users to sign-in. Clicking it should call
            PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication);
        }
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