using UnityEngine;
using UnityEngine.EventSystems;

public class TapToStartScript : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData) {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}