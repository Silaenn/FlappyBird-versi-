using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private void OnMouseDown(){
         // Memastikan AudioSourcee singleton dapat diakses
        if (AudioSourcee.singleton != null)
        {
            AudioSourcee.singleton.PlaySound(1); // Memainkan suara
        }

        // Mencari instance SceneGame di scene
        SceneGame sceneGameInstance = FindObjectOfType<SceneGame>();

        // Jika ditemukan, akses metode LoadSceneWithSound
        if (sceneGameInstance != null)
        {
            StartCoroutine(sceneGameInstance.LoadSceneWithSound("MainMenu", 0.5f));
        }
        else
        {
            Debug.LogError("SceneGame not found in the scene!");
        }
    }
}
