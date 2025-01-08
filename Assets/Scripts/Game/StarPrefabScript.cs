using UnityEngine;

public class StarPrefabScript : MonoBehaviour {

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip starObtainedAudioClip;

    private Level mLevel;
    private Score mScore;

    private void Start() {
        mLevel = LevelManager.GetInstance().Level;
        mScore = LevelManager.GetInstance().Score;
    }

    private void FixedUpdate() {
        transform.position += Vector3.left * (mLevel.speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        if (starObtainedAudioClip != null) {
            audioSource.PlayOneShot(starObtainedAudioClip);
        }

        mScore.stars++;
    }

}