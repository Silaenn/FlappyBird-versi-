using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private void OnMouseDown(){
        if (AudioSourcee.singleton != null)
        {
            AudioSourcee.singleton.PlaySound(1); 
        }

            StartCoroutine(SceneGame.singleton.LoadSceneWithSound("MainMenu", 0.5f));
    }

    public void ClickButton(){
        if (AudioSourcee.singleton != null)
        {
            AudioSourcee.singleton.PlaySound(1); 
        }
    }
}
