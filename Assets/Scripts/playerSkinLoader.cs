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
    private int last2SkinIndex;

    void Start() {
        lastSkinIndex = SkinManager.Instance.skins.Length - 2;
        last2SkinIndex = SkinManager.Instance.skins.Length;
        LoadSkin();
    }

    void LoadSkin() {
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", DefaultSkinIndex);

        // Cek indeks skin dan atur skala sesuai kebutuhan
        if (selectedSkinIndex == 0) {
            // Untuk skin pertama (index 0), gunakan skala lastSkinScale
            transform.localScale = lastSkinScale;
        } 
        else if (selectedSkinIndex == 2) {
            // Untuk skin ketiga (index 2), gunakan skala last2SkinScale
            transform.localScale = last2SkinScale;
        } 
        else {
            // Untuk skin lainnya, gunakan skala default
            transform.localScale = new Vector3(3, 3, 3);
        }

        // Set sprite skin
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

        // Set animator controller sesuai dengan skin yang dipilih
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
