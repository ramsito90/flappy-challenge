using UnityEngine;
using UnityEngine.EventSystems;

public class BtnCloseScript : DualSpriteClickableObject {

    [SerializeField] public GameObject btnSettings;

    private BtnSettingsScript mBtnSettingsScript;

    private new void Start() {
        base.Start();
        mBtnSettingsScript = btnSettings.GetComponent<BtnSettingsScript>();
    }

    public override void OnPointerClick(PointerEventData eventData) {
        mBtnSettingsScript.Close();
    }

}