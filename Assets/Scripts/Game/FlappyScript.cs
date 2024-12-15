using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class FlappyScript : MonoBehaviour {
    
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip gameOverAudioClip;
    [SerializeField] public GameObject pnlGameOver;

    private static FlappyScript instance;

    private Pj mPj;
    private Rigidbody2D mPjRigidbody2D;
    private Animator mAnimator;
    private float mOriginalPositionX;
    private Vector3? mEndPosition;

    private void Awake() {
        instance = this;
        EnhancedTouchSupport.Enable();
    }

    public static FlappyScript GetInstance() {
        return instance;
    }

    private void Start() {
        mPjRigidbody2D = GetComponent<Rigidbody2D>();
        mAnimator = gameObject.GetComponent<Animator>();
        mOriginalPositionX = transform.position.x;

        mPj = LevelManager.GetInstance().Pj;
        mAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(mPj.animator);

        var capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        capsuleCollider2D.offset = new Vector2(mPj.capsuleColliderOffset[0], mPj.capsuleColliderOffset[1]);
        capsuleCollider2D.size = new Vector2(mPj.capsuleColliderSize[0], mPj.capsuleColliderSize[1]);

        mPjRigidbody2D.gravityScale = LevelManager.GetInstance().Level.gravity - mPj.antiGravity;
    }

    public void Jump() {
        mPjRigidbody2D.velocity = Vector2.up * mPj.jumpVelocity;
    }

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(0, 0, mPjRigidbody2D.velocity.y * mPj.rotationSpeed);

        if (transform.position.x != mOriginalPositionX) {
            transform.position += Vector3.left * (transform.position.x - mOriginalPositionX);
        }

        if (mEndPosition != null) {
            if (!Mathf.Approximately(pnlGameOver.transform.position.y, mEndPosition.Value.y)) {
                pnlGameOver.transform.position =
                    Vector3.Lerp(pnlGameOver.transform.position, mEndPosition.Value, 7 * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "roof") {
            return;
        }

        LevelManager.GetInstance().Level.speed = 0f;
        audioSource.clip = gameOverAudioClip;
        audioSource.Play();
        ShowGameOverPanel();
    }
    
    private void ShowGameOverPanel() {
        mEndPosition = new Vector3(pnlGameOver.transform.position.x, 0.3f, pnlGameOver.transform.position.z);
    }

}