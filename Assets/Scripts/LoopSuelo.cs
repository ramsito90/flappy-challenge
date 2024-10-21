using UnityEngine;

public class LoopSuelo : MonoBehaviour {

    [SerializeField] private float speed = 0.65f;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;
    private float _startSizeX;

    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
        _startSizeX = _spriteRenderer.size.x;
    }

    // Update is called once per frame
    private void Update() {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + (speed * Time.deltaTime), _spriteRenderer.size.y);

        if (_spriteRenderer.size.x >= (_startSizeX * 3)) { // solo se muestra el fondo 2 veces seguidas
            _spriteRenderer.size = _startSize;
        }
    }

}