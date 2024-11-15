using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishlinePrefabScript : MonoBehaviour {

    internal float Speed;

    private void FixedUpdate() {
        transform.position += (Vector3.left * (Speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Player")) return;

        Toast.show(TimeSpan.FromSeconds(ScoreScript._totalSeconds).ToString(@"mm\:ss"));

        var totalSeconds = (long)ScoreScript._totalSeconds;
        var boardName = LevelManager.GetInstance().Level.boardName;
        PlayGamesPlatform.Instance.ReportScore(totalSeconds, boardName, (bool success) => {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(boardName, (callback) => {
                if (callback is UIStatus.UserClosedUI or UIStatus.Valid) {
                    SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
                }
            });
        });
    }

}