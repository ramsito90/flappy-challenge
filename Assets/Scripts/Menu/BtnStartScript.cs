using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnStartScript : DualSpriteClickableObject {

    public override void OnPointerClick(PointerEventData eventData) {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene() {
        if (audioSource != null && pressedBtnSound != null) {
            yield return new WaitUntil(() => audioSource.time >= (pressedBtnSound.length - 0.5f));
        }

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 0;
    }

}