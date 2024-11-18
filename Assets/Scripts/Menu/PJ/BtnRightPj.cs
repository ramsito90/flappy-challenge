using UnityEngine.EventSystems;


public class BtnRightPj : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        PjScript.GetInstance().Next();
    }

}