using UnityEngine;

public class BackMusicScript : MonoBehaviour {

    private AudioSource mAudioSource;

    private void Start() {
        mAudioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (PlayerPrefs.GetInt("Music", 1) == 1) {
            Play();
        } else {
            Stop();
        }
    }

    private void Stop() {
        if (mAudioSource.isPlaying) {
            mAudioSource.Stop();
        }
    }

    private void Play() {
        if (!mAudioSource.isPlaying) {
            mAudioSource.Play();
        }
    }

}