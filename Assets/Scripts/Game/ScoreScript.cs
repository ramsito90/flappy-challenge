using System;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI distanciaTextMesh;
    [SerializeField] private TextMeshProUGUI tiempoTextMesh;
    [SerializeField] private TextMeshProUGUI puntuacionTextMesh;

    private static float _totalDistance = 0f;
    public static float _totalSeconds = 0f;
    private float _levelSpeed;

    private void Start() {
        _levelSpeed = LevelManager.GetInstance().Level.speed;
        _totalSeconds = 0f;
        _totalDistance = 0f;
    }

    // Update is called once per frame
    private void Update() {
        _totalDistance += _levelSpeed * Time.deltaTime;
        _totalSeconds += Time.deltaTime;

        distanciaTextMesh.text = $"{_totalDistance:0.0}";
        tiempoTextMesh.text = TimeSpan.FromSeconds(_totalSeconds).ToString(@"mm\:ss");
        puntuacionTextMesh.text = $"{LevelManager.GetInstance().Score.pipes:0}";
    }
    
    

}