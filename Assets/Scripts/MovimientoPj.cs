using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MovimientoPj : MonoBehaviour {

    [SerializeField] private float velocity = 1.7f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D _pjRigidbody2D;

    private void Awake() {
        EnhancedTouchSupport.Enable();
    }

    // Start is called before the first frame update
    private void Start() {
        _pjRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) {
            Salto();
            return;
        }

        //TODO quitar, irá con el botón de abajo
        if (Touch.activeFingers.Count == 1 && Touch.activeFingers[0].currentTouch.phase == UnityEngine.InputSystem.TouchPhase.Ended) {
            Salto();
        }
    }

    private void Salto() {
        _pjRigidbody2D.velocity = Vector2.up * velocity;
    }

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(0, 0, _pjRigidbody2D.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // GameManager.instance.GameOver();
    }

}