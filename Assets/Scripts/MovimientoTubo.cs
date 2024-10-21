using UnityEngine;

public class MovimientoTubo : MonoBehaviour {

    [SerializeField] private float speed = 0.65f;

    // Update is called once per frame
    private void Update() {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }

}