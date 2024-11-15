using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnStartScript : DualSpriteClickableObject {

    private new void Start() {
        base.Start();
    }

    public override void OnPointerClick(PointerEventData eventData) {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene() {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

}