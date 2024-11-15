using UnityEngine;

public class PipePrefabScript : MonoBehaviour {

    internal float Speed;

    private void FixedUpdate() {
        transform.position += (Vector3.left * (Speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            LevelManager.GetInstance().Score.pipes++;
        }
    }

}