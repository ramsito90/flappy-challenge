using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;

public class FlappyScript : MonoBehaviour {
    
    private static FlappyScript instance;

    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D _pjRigidbody2D;
    private float _originalPositionX;

    private void Awake() {
        instance = this;
        EnhancedTouchSupport.Enable();
    }
    
    public static FlappyScript GetInstance() {
        return instance;
    }

    private void Start() {
        _pjRigidbody2D = GetComponent<Rigidbody2D>();
        _originalPositionX = transform.position.x;
        _pjRigidbody2D.gravityScale = LevelManager.GetInstance().Level.gravity;
    }

    public void Jump() {
        _pjRigidbody2D.velocity = Vector2.up * velocity;
    }

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(0, 0, _pjRigidbody2D.velocity.y * rotationSpeed);
        if (transform.position.x != _originalPositionX) {
            transform.position += Vector3.left * (transform.position.x - _originalPositionX);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "roof") {
            return;
        }

        //TODO nivel fallado
        //TODO mostrar escena de resumen
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

}