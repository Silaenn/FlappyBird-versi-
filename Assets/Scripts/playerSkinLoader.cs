using UnityEngine;

public class playerSkinLoader : MonoBehaviour {
    public SpriteRenderer playerRenderer;
    public Animator playerAnimator;
    public RuntimeAnimatorController[] animatorControllers;
    public Sprite defaultSprite;
    public RuntimeAnimatorController defaultAnimatorController;

    private const int DefaultSkinIndex = 0;

    public Vector3 lastSkinScale = new Vector3(0.0865605f, 0.0865605f, 0.0865605f);
    public Vector3 last2SkinScale = new Vector3(0.1089065f, 0.1089065f, 0.0865605f);

    private int lastSkinIndex;
    private int las2tSkinIndex;

    void Start() {
        lastSkinIndex = SkinManager.Instance.skins.Length - 1;
        las2tSkinIndex = SkinManager.Instance.skins.Length - 2;
        LoadSkin();

    }

    void LoadSkin() {
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", DefaultSkinIndex);

        if (SkinManager.Instance != null && SkinManager.Instance.skins != null) {
            if (selectedSkinIndex >= 0 && selectedSkinIndex < SkinManager.Instance.skins.Length) {
                playerRenderer.sprite = SkinManager.Instance.skins[selectedSkinIndex];
            } else {
                playerRenderer.sprite = SkinManager.Instance.skins[DefaultSkinIndex];
                Debug.LogWarning("Invalid skin index, default skin applied.");
            }
        } else {
            if (defaultSprite != null) {
                playerRenderer.sprite = defaultSprite;
            } else {
                Debug.LogError("No default sprite assigned and SkinManager not available.");
            }
        }

        if (selectedSkinIndex >= 0 && selectedSkinIndex < animatorControllers.Length) {
            playerAnimator.runtimeAnimatorController = animatorControllers[selectedSkinIndex];
        } else {
            if (defaultAnimatorController != null) {
                playerAnimator.runtimeAnimatorController = defaultAnimatorController;
            } else if (animatorControllers.Length > DefaultSkinIndex) {
                playerAnimator.runtimeAnimatorController = animatorControllers[DefaultSkinIndex];
            } else {
                Debug.LogError("No valid animator controller available.");
            }
        }
        if (selectedSkinIndex == lastSkinIndex) {
            transform.localScale = lastSkinScale;
        }
        else if(selectedSkinIndex == las2tSkinIndex){
            transform.localScale = last2SkinScale;
        }
         else {
            // Jika skin lain, gunakan scale default (1,1,1)
            transform.localScale = new Vector3(4,4,4);
        }
    }

    
}