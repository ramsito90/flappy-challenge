using UnityEngine;

public class LoopSuelo : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;
    private float _startSizeX;
    private float _speed = 0.65f;

    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
        _startSizeX = _spriteRenderer.size.x;
        _speed = LevelManager.GetInstance().Level.speed;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        _spriteRenderer.size =
            new Vector2(_spriteRenderer.size.x + (_speed * Time.fixedDeltaTime), _spriteRenderer.size.y);

        if (_spriteRenderer.size.x >= (_startSizeX * 3)) {
            // solo se muestra el fondo 2 veces seguidas
            _spriteRenderer.size = _startSize;
        }
    }

}