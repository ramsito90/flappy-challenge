using UnityEngine;

public class PipeGeneratorScript : MonoBehaviour {

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject starPrefab;

    private float mTimer = -1;
    private int mCurrentPipe = 0;
    private bool mGeneratedStar = false;

    private Level mLevel;

    private void Start() {
        mLevel = LevelManager.GetInstance().Level;
    }

    private void Update() {
        if (mTimer > mLevel.pipe.distance) {
            GeneratePipe();
            mTimer = 0;
            mGeneratedStar = false;
        } else if (mGeneratedStar == false && mTimer > mLevel.pipe.distance / 2) {
            GenerateStar();
            mGeneratedStar = true;
        }

        // mTimer += Time.deltaTime;
        mTimer += (Time.deltaTime * mLevel.speed);
    }

    private void GeneratePipe() {
        if (mLevel.pipe.heights.Length >= mCurrentPipe + 1) {
            var pipeHeight = mLevel.pipe.heights[mCurrentPipe];
            var posicion = transform.position + new Vector3(0, pipeHeight);
            var nuevosTubos = Instantiate(pipePrefab, posicion, Quaternion.identity);
            //TODO espaciado de los tubos parametrizable
            // Destroy(nuevosTubos, 10f);
        }
        else {
            var posicion = transform.position;
            var nuevaMeta = Instantiate(pipePrefab, posicion, Quaternion.identity);
            //TODO espaciar más los tubos
            nuevaMeta.GetComponent<PipePrefabScript>().SetFinishLine(true);
            // Destroy(nuevaMeta, 10f);
        }

        mCurrentPipe++;
    }
    
    
    private void GenerateStar() {
        if (mLevel.pipe.stars != null && mLevel.pipe.stars.Length >= mCurrentPipe + 1) {
            var starHeight = mLevel.pipe.stars[mCurrentPipe];
            var starPosition = transform.position + new Vector3(0, starHeight);
            var newStar = Instantiate(starPrefab, starPosition, Quaternion.identity);
            // Destroy(newStar, 10f);
        }
    }

}