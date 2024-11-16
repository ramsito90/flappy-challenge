using GooglePlayGames;
using UnityEngine.EventSystems;

public class BtnInfoScript : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }

}