using System;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI distanciaTextMesh;
    [SerializeField] private TextMeshProUGUI tiempoTextMesh;
    [SerializeField] private TextMeshProUGUI puntuacionTextMesh;

    private static float totalDistance = 0f;
    public static float totalSeconds = 0f;
    private Level mMLevel;

    private void Start() {
        mMLevel = LevelManager.GetInstance().Level;
        totalSeconds = 0f;
        totalDistance = 0f;
    }

    // Update is called once per frame
    private void Update() {
        totalDistance += mMLevel.speed * Time.deltaTime;
        totalSeconds += Time.deltaTime;

        distanciaTextMesh.text = $"{totalDistance:0.0}";
        tiempoTextMesh.text = TimeSpan.FromSeconds(totalSeconds).ToString(@"mm\:ss");
        puntuacionTextMesh.text = $"{LevelManager.GetInstance().Score.pipes:0}";
    }

}