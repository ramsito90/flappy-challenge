using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnFireScript : MonoBehaviour, IPointerClickHandler {

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip powerUpAudioClip;
    [SerializeField] public SpriteRenderer starsPercent;
    [SerializeField] public Sprite spriteEnabled;
    [SerializeField] public Sprite spriteDisabled;
    [SerializeField] public Sprite sprite0_3;
    [SerializeField] public Sprite sprite1_3;
    [SerializeField] public Sprite sprite2_3;
    [SerializeField] public Sprite sprite3_3;

    private Score mScore;
    private Level mMLevel;
    private float mOriginalSpeed;
    private SpriteRenderer mSpriteRenderer;
    private BoxCollider2D mBoxCollider2D;

    private void Start() {
        mScore = LevelManager.GetInstance().Score;
        mMLevel = LevelManager.GetInstance().Level;
        mOriginalSpeed = mMLevel.speed;
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mBoxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate() {
        starsPercent.sprite = mScore.stars switch {
            0 => sprite0_3,
            1 => sprite1_3,
            2 => sprite2_3,
            3 => sprite3_3,
            _ => starsPercent.sprite
        };

        if (mScore.stars >= 3) {
            mSpriteRenderer.sprite = spriteEnabled;
            mBoxCollider2D.enabled = true;
        }
        else {
            mSpriteRenderer.sprite = spriteDisabled;
            mBoxCollider2D.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        mScore.stars = 0;
        
        if (powerUpAudioClip != null) {
            audioSource.PlayOneShot(powerUpAudioClip);
        }

        mMLevel.speed = mOriginalSpeed / 2;

        RestoreSpeed();
        //TODO ataque especial
    }

    private async Task RestoreSpeed() {
        await Task.Delay(2000);
        mMLevel.speed = mOriginalSpeed;
    }

}