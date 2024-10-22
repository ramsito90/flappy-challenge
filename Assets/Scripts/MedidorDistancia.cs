using TMPro;
using UnityEngine;

public class MedidorDistancia : MonoBehaviour {

    [SerializeField] private float speed = 0.65f;

    private TextMeshProUGUI _distanciaTextMesh;
    private float _totalDistance = 0f;

    // Start is called before the first frame update
    private void Start() {
        _distanciaTextMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update() {
        _totalDistance += speed * Time.deltaTime;
        _distanciaTextMesh.text = $"{_totalDistance:0.0}";
    }

}