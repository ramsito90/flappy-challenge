using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [SerializeField] private GameObject tubos;

    private float mTimer;
    private int mCurrentPipe = 0;

    private Level mLevel;

    private void Start() {
        mLevel = LevelManager.GetInstance().Level;
    }

    private void Update() {
        if (mTimer > mLevel.pipe.distance) {
            GeneratePipe();
            mTimer = 0;
        }

        mTimer += Time.deltaTime;
    }

    private void GeneratePipe() {
        if (mLevel.pipe.heights.Length >= mCurrentPipe + 1) {
            var pipeHeight = mLevel.pipe.heights[mCurrentPipe];
            var posicion = transform.position + new Vector3(0, pipeHeight);
            var nuevosTubos = Instantiate(tubos, posicion, Quaternion.identity);
            //TODO espaciado de los tubos parametrizable
            Destroy(nuevosTubos, 10f);
        }
        else {
            var posicion = transform.position;
            var nuevaMeta = Instantiate(tubos, posicion, Quaternion.identity);
            //TODO espaciar más los tubos
            nuevaMeta.GetComponent<PipePrefabScript>().SetFinishLine(true);
            Destroy(nuevaMeta, 10f);
        }

        mCurrentPipe++;
    }

}