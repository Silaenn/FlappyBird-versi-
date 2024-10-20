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
        StartCoroutine(SceneGame.singleton.LoadSceneWithSound("MainGame", 0.5f));
    }

}
