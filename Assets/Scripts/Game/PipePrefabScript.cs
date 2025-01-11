using System;
using System.Collections;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipePrefabScript : MonoBehaviour {

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip pipeCrossedAudioClip;
    [SerializeField] public AudioClip finishLineCrossedAudioClip;

    private bool mIsFinishLine;
    private Level mLevel;

    private void Start() {
        mLevel = LevelManager.GetInstance().Level;
        if (audioSource == null || pipeCrossedAudioClip == null || finishLineCrossedAudioClip == null) {
            throw new Exception("AudioSource, PipeCrossedAudioClip y FinishLineCrossedAudioClip no pueden ser nulos");
        }

        var sprites = Resources.LoadAll<Sprite>("Sprites/SimpleStyle1");

        if (!mIsFinishLine) {
            var sprite = sprites.FirstOrDefault(s => s.name == mLevel.pipe.spriteUp);
            if (sprite != null) {
                transform.Find("tubo_sup").GetComponent<SpriteRenderer>().sprite = sprite;
            }

            sprite = sprites.FirstOrDefault(s => s.name == mLevel.pipe.spriteDown);
            if (sprite != null) {
                transform.Find("tubo_inf").GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
        else {
            var sprite = sprites.FirstOrDefault(s => s.name == mLevel.pipe.spriteFinishLine);
            if (sprite != null) {
                transform.Find("tubo_sup").GetComponent<SpriteRenderer>().sprite = sprite;
                transform.Find("tubo_inf").GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
    }

    private void FixedUpdate() {
        transform.position += Vector3.left * (mLevel.speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Player")) return;

        LevelManager.GetInstance().Score.pipes++;

        if (mIsFinishLine) {
            Time.timeScale = 0;
            Toast.show(TimeSpan.FromSeconds(ScoreScript.totalSeconds).ToString(@"mm\:ss"));
            audioSource.clip = finishLineCrossedAudioClip;
            audioSource.Play();
            StartCoroutine(ChangeScene());
        }
        else {
            audioSource.PlayOneShot(pipeCrossedAudioClip);
        }
    }

    private IEnumerator ChangeScene() {
        if (audioSource != null && finishLineCrossedAudioClip != null) {
            yield return new WaitUntil(() => audioSource.time >= (finishLineCrossedAudioClip.length - 0.5f));
        }

        var totalMillis = (long)ScoreScript.totalSeconds * 1000;
        var boardName = LevelManager.GetInstance().Level.boardName;
        if (Application.platform == RuntimePlatform.Android && boardName != null) {
            PlayGamesPlatform.Instance.ReportScore(totalMillis, boardName, _ => {
                PlayGamesPlatform.Instance.ShowLeaderboardUI(boardName, (callback) => {
                    if (callback is UIStatus.UserClosedUI or UIStatus.Valid) {
                        Time.timeScale = 1;
                        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
                    }
                });
            });
        }
        else {
            Time.timeScale = 1;
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }

    public void SetFinishLine(bool isFinishLine) {
        mIsFinishLine = isFinishLine;
    }

}