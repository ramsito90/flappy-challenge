using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSoundScript : MonoBehaviour, IPointerClickHandler {

    [SerializeField] public Sprite soundSprinte;
    [SerializeField] public Sprite mutedSoundSprinte;
    [SerializeField] public GameObject backMusic;

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
        backMusic.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().sprite = soundSprinte;
    }

    private void StopMusic() {
        backMusic.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<SpriteRenderer>().sprite = mutedSoundSprinte;
    }

}