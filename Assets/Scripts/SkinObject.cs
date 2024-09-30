using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinObject : MonoBehaviour
{
    public int skinIndex;
    public SkinManager skinManager;

    private void OnMouseDown() {
        skinManager.ChangeSkin(skinIndex);
        AudioSourcee.singleton.PlaySound(1); 
    
        SceneGame sceneGameInstance = FindObjectOfType<SceneGame>();

         if (sceneGameInstance != null)
        {
            StartCoroutine(sceneGameInstance.LoadSceneWithSound("MainGame", 0.5f));
        }
        else
        {
            Debug.LogError("SceneGame not found in the scene!");
        }
    }

}
