using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class MovimientoPj : MonoBehaviour {

    [SerializeField] private float velocity = 1.7f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D _pjRigidbody2D;
    private float _originalPositionX;

    private void Awake() {
        EnhancedTouchSupport.Enable();
    }

    private void Start() {
        _pjRigidbody2D = GetComponent<Rigidbody2D>();
        _originalPositionX = transform.position.x;
    }

    public void Salto() {
        _pjRigidbody2D.velocity = Vector2.up * velocity;
    }

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(0, 0, _pjRigidbody2D.velocity.y * rotationSpeed);
        if (transform.position.x != _originalPositionX) {
            transform.position += Vector3.left * (transform.position.x - _originalPositionX);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // GameManager.instance.GameOver();
    }

}