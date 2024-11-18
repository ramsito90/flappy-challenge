using TMPro;
using UnityEngine;


public class PjScript : MonoBehaviour {

    [SerializeField] private GameObject pjName;

    private static PjScript instance;

    private Animator mAnimator;
    private TextMeshPro mPjNameTextMeshPro;

    public void Awake() {
        instance = this;
    }

    public static PjScript GetInstance() {
        return instance;
    }

    private void Start() {
        mAnimator = gameObject.GetComponent<Animator>();
        mPjNameTextMeshPro = pjName.GetComponent<TextMeshPro>();

        var pj = PlayerPrefs.GetInt("Pj", 1);
        LoadPj(1, pj);
    }

    public void Next() {
        var level = PlayerPrefs.GetInt("Pj", 1);
        level++;
        if (!LoadPj(1, level)) {
            level = 1;
            LoadPj(1, level);
        }

        PlayerPrefs.SetInt("Pj", level);
        PlayerPrefs.Save();
    }

    public void Previous() {
        var level = PlayerPrefs.GetInt("Pj", 1);
        level--;
        if (!LoadPj(1, level)) {
            level = 2;
            LoadPj(1, level);
        }

        PlayerPrefs.SetInt("Pj", level);
        PlayerPrefs.Save();
    }

    private bool LoadPj(int worldNumber, int levelNumber) {
        var resource = Resources.Load<TextAsset>($"Pjs/World{worldNumber}/pj{levelNumber}");
        if (resource == null) {
            return false;
        }

        var resourceText = resource.text;
        var pj = JsonUtility.FromJson<Pj>(resourceText);
        LevelManager.GetInstance().Score.reset();
        LevelManager.GetInstance().Pj = pj;
        mAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(pj.animator);
        mPjNameTextMeshPro.text = pj.name;
        return true;
    }

}