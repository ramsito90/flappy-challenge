using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnShowCreditsScript : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("CreditsScene", LoadSceneMode.Single);
    }

}