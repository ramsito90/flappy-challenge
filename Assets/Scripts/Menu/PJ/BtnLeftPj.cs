using UnityEngine.EventSystems;


public class BtnLeftPj : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        PjScript.GetInstance().Previous();
    }

}