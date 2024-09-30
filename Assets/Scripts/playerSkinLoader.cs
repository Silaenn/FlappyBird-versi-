using UnityEngine;

public class playerSkinLoader : MonoBehaviour {
    public SpriteRenderer playerRenderer;
    public Animator playerAnimator;
    public RuntimeAnimatorController[] animatorControllers;
    public Sprite defaultSprite;
    public RuntimeAnimatorController defaultAnimatorController;

    private const int DefaultSkinIndex = 0;

    void Start() {
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
    }
}