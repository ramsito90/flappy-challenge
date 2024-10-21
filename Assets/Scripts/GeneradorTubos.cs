using UnityEngine;

public class GeneradorTubos : MonoBehaviour {

    [SerializeField] private float maxDistanceTime = 2f;
    [SerializeField] private float heightRange = 0.4f;
    [SerializeField] private GameObject tubos;

    private float _timer;

    // Update is called once per frame
    private void Update() {
        if (_timer > maxDistanceTime) {
            GenerarTubo();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void GenerarTubo() {
        var posicion = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        var nuevosTubos = Instantiate(tubos, posicion, Quaternion.identity);

        Destroy(nuevosTubos, 10f);
    }

}