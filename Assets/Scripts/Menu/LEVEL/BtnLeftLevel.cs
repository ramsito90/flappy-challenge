using UnityEngine.EventSystems;


public class BtnLeftLevel : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        LevelScript.GetInstance().Previous();
    }

}