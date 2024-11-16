using UnityEngine.EventSystems;

public class BtnCloseScript : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        BtnSettingsScript.GetInstance().Close();
    }

}