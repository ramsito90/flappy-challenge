using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;

public class FlappyScript : MonoBehaviour {
    
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip gameOverAudioClip;

    private static FlappyScript instance;

    private Pj mPj;
    private Rigidbody2D mPjRigidbody2D;
    private Animator mAnimator;
    private float mOriginalPositionX;

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
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "roof") {
            return;
        }
        
        Time.timeScale = 0;
        audioSource.clip = gameOverAudioClip;
        audioSource.Play();
        StartCoroutine(ChangeScene());
    }
    
    private IEnumerator ChangeScene() {
        if (audioSource != null && gameOverAudioClip != null) {
            yield return new WaitUntil(() => audioSource.time >= gameOverAudioClip.length);
        }

        //TODO mostrar escena de resumen
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

}