using UnityEngine;
using UnityEngine.EventSystems;

public class BtnJumpScript : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        Time.timeScale = 1;
        FlappyScript.GetInstance().Salto();
    }

}