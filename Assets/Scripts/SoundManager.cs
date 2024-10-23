using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManager : MonoBehaviour, IPointerClickHandler {

    [SerializeField] public Sprite soundSprinte;
    [SerializeField] public Sprite mutedSoundSprinte;
    [SerializeField] public GameObject backMusic;

    private bool _activeMusic = true;

    public void OnPointerClick(PointerEventData eventData) {
        if (_activeMusic) {
            backMusic.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<SpriteRenderer>().sprite = mutedSoundSprinte;
        }
        else {
            backMusic.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = soundSprinte;
        }
        _activeMusic = !_activeMusic;
    }

}