using System;
using TMPro;
using UnityEngine;

public class MedidorTiempo : MonoBehaviour {

    [SerializeField] private float speed = 0.65f;

    private TextMeshProUGUI _tiempoTextMesh;
    private float _totalSeconds = 0f;

    // Start is called before the first frame update
    private void Start() {
        _tiempoTextMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update() {
        _totalSeconds += Time.deltaTime;
        var time = TimeSpan.FromSeconds(_totalSeconds);
        _tiempoTextMesh.text = time.ToString(@"mm\:ss");
    }

}