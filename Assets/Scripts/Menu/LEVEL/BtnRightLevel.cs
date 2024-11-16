using UnityEngine.EventSystems;


public class BtnRightLevel : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        LevelScript.GetInstance().Next();
    }

}