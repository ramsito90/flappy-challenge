using System;
using TMPro;
using UnityEngine;


public class MedidorTiempo : MonoBehaviour {
    
    [SerializeField] private float speed = 0.65f;
    
    private TextMeshProUGUI _tiempoTextMesh;
    private float _totalDistance = 0f;

    // Start is called before the first frame update
    private void Start() {
        _tiempoTextMesh = GetComponent<TextMeshProUGUI>();
    }
    
    // Update is called once per frame
    private void Update() {
        _totalDistance += speed * Time.deltaTime;
        // _tiempoTextMesh.text = _totalDistance.ToString();
        _tiempoTextMesh.text = $"{_totalDistance:0.0}";
    }

}