using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [SerializeField] private GameObject tubos;
    [SerializeField] private GameObject meta;

    private float _timer;
    private int _currentPipe = 0;

    private Level _level;

    private void Start() {
        _level = LevelManager.GetInstance().Level;
    }

    private void Update() {
        if (_timer > _level.pipe.distance) {
            GeneratePipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void GeneratePipe() {
        if (_level.pipe.heights.Length >= _currentPipe + 1) {
            var pipeHeight = _level.pipe.heights[_currentPipe];
            var posicion = transform.position + new Vector3(0, pipeHeight);
            var nuevosTubos = Instantiate(tubos, posicion, Quaternion.identity);
            nuevosTubos.GetComponent<PipePrefabScript>().Speed = _level.speed;
            Destroy(nuevosTubos, 10f);
        }
        else {
            var posicion = transform.position + new Vector3(0, 0);
            var nuevaMeta = Instantiate(meta, posicion, Quaternion.identity);
            nuevaMeta.GetComponent<FinishlinePrefabScript>().Speed = _level.speed;
            Destroy(nuevaMeta, 10f);
        }

        _currentPipe++;
    }

}