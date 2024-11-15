using UnityEngine;
using UnityEngine.EventSystems;


public abstract class DualSpriteClickableObject : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
    
    [SerializeField] public Sprite pressedBtnSprite;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip pressedBtnSound;  
    
    private Sprite mNotPressedBtnSprite;

    public void Start() {
        mNotPressedBtnSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
     
    public abstract void OnPointerClick(PointerEventData eventData);
    
    public void OnPointerDown(PointerEventData eventData) {
        gameObject.GetComponent<SpriteRenderer>().sprite = pressedBtnSprite;
    }

    public void OnPointerUp(PointerEventData eventData) {
        gameObject.GetComponent<SpriteRenderer>().sprite = mNotPressedBtnSprite;
        if (audioSource != null && pressedBtnSound != null) {
            audioSource.clip = pressedBtnSound;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

}