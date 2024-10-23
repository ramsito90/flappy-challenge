using UnityEngine;

public class MovimientoTubo : MonoBehaviour {

    [SerializeField] private float speed = 0.65f;

    private void FixedUpdate() {
        transform.position += (Vector3.left * (speed * Time.fixedDeltaTime));
        // var wantedPosition = transform.position + (Vector3.left * (speed * Time.fixedDeltaTime));
        // transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 100);
    }

}