using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSettingsScript : DualSpriteClickableObject {

    [SerializeField] public GameObject pnlSettings;

    private const float Speed = 4;
    private Vector3 mEndPosition;
    private bool mPanelShown = false;

    private new void Start() {
        base.Start();
        mEndPosition = pnlSettings.transform.position;
    }

    public override void OnPointerClick(PointerEventData eventData) {
        if (!mPanelShown) {
            Open();
        }
        else {
            Close();
        }
    }

    private void Open() {
        mPanelShown = true;
        mEndPosition = new Vector3(pnlSettings.transform.position.x, -0.1f, pnlSettings.transform.position.z);
    }

    public void Close() {
        mPanelShown = false;
        mEndPosition = new Vector3(pnlSettings.transform.position.x, 1.7f, pnlSettings.transform.position.z);
    }

    private void FixedUpdate() {
        if (pnlSettings.transform.position != mEndPosition) {
            pnlSettings.transform.position =
                Vector3.Lerp(pnlSettings.transform.position, mEndPosition, Speed * Time.deltaTime);
        }
    }

}