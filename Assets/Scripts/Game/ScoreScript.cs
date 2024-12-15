using System;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI distanciaTextMesh;
    [SerializeField] private TextMeshProUGUI tiempoTextMesh;
    [SerializeField] private TextMeshProUGUI puntuacionTextMesh;
    
    [SerializeField] public GameObject txtDistGameOver;
    [SerializeField] public GameObject txtObstGameOver;
    [SerializeField] public GameObject txtTimeGameOver;

    private static float totalDistance = 0f;
    public static float totalSeconds = 0f;
    
    private Level mMLevel;
    private TextMeshPro mTxtDistGameOverTextMesh;
    private TextMeshPro mTxtObstGameOverTextMesh;
    private TextMeshPro mTxtTimeGameOverTextMesh;

    private void Start() {
        mMLevel = LevelManager.GetInstance().Level;
        totalSeconds = 0f;
        totalDistance = 0f;
        
        mTxtDistGameOverTextMesh = txtDistGameOver.GetComponent<TextMeshPro>();
        mTxtObstGameOverTextMesh = txtObstGameOver.GetComponent<TextMeshPro>();
        mTxtTimeGameOverTextMesh = txtTimeGameOver.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    private void Update() {
        if (mMLevel.speed > 0f) {
            totalDistance += mMLevel.speed * Time.deltaTime;
            totalSeconds += Time.deltaTime;
        }

        distanciaTextMesh.text = $"{totalDistance:0.0}";
        tiempoTextMesh.text = TimeSpan.FromSeconds(totalSeconds).ToString(@"mm\:ss");
        puntuacionTextMesh.text = $"{LevelManager.GetInstance().Score.pipes:0}";

        mTxtDistGameOverTextMesh.text = "Dist: " + distanciaTextMesh.text;
        mTxtObstGameOverTextMesh.text = "Obst: " + puntuacionTextMesh.text + "/" + LevelManager.GetInstance().Level.pipe.heights.Length;
        mTxtTimeGameOverTextMesh.text = "Time: " + tiempoTextMesh.text;
    }

}