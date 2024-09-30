using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public Sprite[] skins;
    public static SkinManager Instance;

    private void Awake() {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    public void ChangeSkin(int index){
        if (index >= 0 && index < skins.Length){
            PlayerPrefs.SetInt("SelectedSkin", index);
            PlayerPrefs.Save();
        }
    }
}
