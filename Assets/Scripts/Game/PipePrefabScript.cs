using System;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipePrefabScript : MonoBehaviour {

    [SerializeField] public Sprite finishLineSprite;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip pipeCrossedAudioClip;
    [SerializeField] public AudioClip finishLineCrossedAudioClip;

    private bool mIsFinishLine = false;
    private Level mLevel;

    private void Start() {
        mLevel = LevelManager.GetInstance().Level;
        if (audioSource == null || pipeCrossedAudioClip == null || finishLineCrossedAudioClip == null) {
            throw new Exception("AudioSource, PipeCrossedAudioClip y FinishLineCrossedAudioClip no pueden ser nulos");
        }
    }

    private void FixedUpdate() {
        transform.position += Vector3.left * (mLevel.speed * Time.fixedDeltaTime);
    }

    private void Update() {
        if (mIsFinishLine && Time.timeScale == 0 && audioSource.time >= finishLineCrossedAudioClip.length) {
            ChangeScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Player")) return;

        LevelManager.GetInstance().Score.pipes++;

        if (mIsFinishLine) {
            Time.timeScale = 0;
            Toast.show(TimeSpan.FromSeconds(ScoreScript.totalSeconds).ToString(@"mm\:ss"));
            audioSource.clip = finishLineCrossedAudioClip;
            audioSource.Play();
        }
        else {
            audioSource.PlayOneShot(pipeCrossedAudioClip);
        }
    }

    private void ChangeScene() {
        Time.timeScale = 1;
        var totalSeconds = (long)ScoreScript.totalSeconds;
        var boardName = LevelManager.GetInstance().Level.boardName;
        if (Application.platform == RuntimePlatform.Android) {
            PlayGamesPlatform.Instance.ReportScore(totalSeconds, boardName, _ => {
                PlayGamesPlatform.Instance.ShowLeaderboardUI(boardName, (callback) => {
                    if (callback is UIStatus.UserClosedUI or UIStatus.Valid) {
                        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
                    }
                });
            });
        }
        else {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }

    public void SetFinishLine(bool isFinishLine) {
        mIsFinishLine = isFinishLine;
        if (isFinishLine) {
            var tuboSup = transform.GetChild(0).gameObject;
            tuboSup.GetComponent<SpriteRenderer>().sprite = finishLineSprite;
            var tuboInf = transform.GetChild(1).gameObject;
            tuboInf.GetComponent<SpriteRenderer>().sprite = finishLineSprite;
        }
    }

}