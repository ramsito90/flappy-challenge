using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class BtnBackScript : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
    
}