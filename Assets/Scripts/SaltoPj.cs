using UnityEngine;
using UnityEngine.EventSystems;

public class SaltoPj : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler  {

    [SerializeField] public GameObject flappy;
    [SerializeField] public Sprite pressedBtnSprite;

    private MovimientoPj _movimientoPj;
    private Sprite _notPressedBtnSprite;

    private void Start() {
        _movimientoPj = flappy.GetComponent<MovimientoPj>();
        _notPressedBtnSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Sprite Clicked");
        _movimientoPj.Salto();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        gameObject.GetComponent<SpriteRenderer>().sprite = pressedBtnSprite;
    }

    public void OnPointerUp(PointerEventData eventData) {
        gameObject.GetComponent<SpriteRenderer>().sprite = _notPressedBtnSprite;
    }



}