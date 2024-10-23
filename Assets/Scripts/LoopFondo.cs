using UnityEngine;

public class LoopFondo : MonoBehaviour {

    [SerializeField] private float speed = 0.65f;
    [SerializeField] public GameObject otherBackground;

    private void Start() {
        // fixed position
        if (transform.position.x > otherBackground.transform.position.x) {
            OnBecameInvisible();
        }
    }

    private void FixedUpdate() {
        transform.position += (Vector3.left * (speed * Time.fixedDeltaTime));
    }
    
    private void OnBecameInvisible() {
        transform.position = otherBackground.transform.position + (Vector3.right * otherBackground.GetComponent<SpriteRenderer>().bounds.size.x);
    }

}