using UnityEngine;
using UnityEngine.EventSystems;

public class BtnFfScript : DualSpriteClickableObject {
    
    [SerializeField] public AudioSource audioSourceBackgroundMusic;

    private Level mMLevel;
    private float mOriginalSpeed;

    public void Start() {
        base.Start();
        mMLevel = LevelManager.GetInstance().Level;
        mOriginalSpeed = mMLevel.speed;
    }

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        mMLevel.speed = mOriginalSpeed * 1.5f; //TODO parametrizable por PJ
        audioSourceBackgroundMusic.pitch = 1.5f;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        mMLevel.speed = mOriginalSpeed;
        audioSourceBackgroundMusic.pitch = 1f;
    }


    public override void OnPointerClick(PointerEventData eventData) {
    }

}