using UnityEngine;


public class LevelScript : MonoBehaviour {

    private static LevelScript instance;

    private SpriteRenderer mSpriteRenderer;

    public void Awake() {
        instance = this;
    }

    public static LevelScript GetInstance() {
        return instance;
    }

    private void Start() {
        mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        var level = PlayerPrefs.GetInt("Level", 1);
        LoadLevel(1, level);
    }

    public void Next() {
        var level = PlayerPrefs.GetInt("Level", 1);
        level++;
        if (!LoadLevel(1, level)) {
            level = 1;
            LoadLevel(1, level);
        }

        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    public void Previous() {
        var level = PlayerPrefs.GetInt("Level", 1);
        level--;
        if (!LoadLevel(1, level)) {
            level = 2; //TODO coger del json de world
            LoadLevel(1, level);
        }

        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    private bool LoadLevel(int worldNumber, int levelNumber) {
        var resource = Resources.Load<TextAsset>($"Levels/World{worldNumber}/level{levelNumber}");
        if (resource == null) {
            return false;
        }

        var resourceText = resource.text;
        var level = JsonUtility.FromJson<Level>(resourceText);
        LevelManager.GetInstance().Score.reset();
        LevelManager.GetInstance().Level = level;
        mSpriteRenderer.sprite = Resources.Load<Sprite>(level.sprite);
        return true;
    }

}