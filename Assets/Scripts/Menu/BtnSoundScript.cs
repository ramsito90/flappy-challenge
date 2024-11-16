using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSoundScript : MonoBehaviour, IPointerClickHandler {

    [SerializeField] public Sprite soundSprinte;
    [SerializeField] public Sprite mutedSoundSprinte;

    private void Start() {
        if (PlayerPrefs.GetInt("Music", 1) == 1) {
            PlayMusic();
        } else {
            StopMusic();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (PlayerPrefs.GetInt("Music", 1) == 1) {
            StopMusic();
            PlayerPrefs.SetInt("Music", 0);
        } else {
            PlayerPrefs.SetInt("Music", 1);
            PlayMusic();
        }

        PlayerPrefs.Save();
    }

    private void PlayMusic() {
        gameObject.GetComponent<SpriteRenderer>().sprite = soundSprinte;
    }

    private void StopMusic() {
        gameObject.GetComponent<SpriteRenderer>().sprite = mutedSoundSprinte;
    }

}