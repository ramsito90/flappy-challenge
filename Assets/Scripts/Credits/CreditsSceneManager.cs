using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneManager : MonoBehaviour {

    [SerializeField] public GameObject pnlTexts;

    private Vector3 mEndPosition;

    private void Start() {
        mEndPosition = new Vector3(pnlTexts.transform.position.x, 12f, pnlTexts.transform.position.z);
    }

    private void FixedUpdate() {
        pnlTexts.transform.position = Vector3.Lerp(pnlTexts.transform.position, mEndPosition, 0.5f * Time.deltaTime);
    }
    
    private void Update() {
        if (pnlTexts.transform.position.y >= (mEndPosition.y - 0.5f)) {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
        if (Application.platform == RuntimePlatform.Android && UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame) {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }

}