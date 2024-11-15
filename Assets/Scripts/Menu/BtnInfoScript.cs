using GooglePlayGames;
using UnityEngine.EventSystems;

public class BtnInfoScript : DualSpriteClickableObject {

    private new void Start() {
        base.Start();
    }

    public override void OnPointerClick(PointerEventData eventData) {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }

}