using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGame : MonoBehaviour
{
public void StartGame()
{
    AudioSourcee.singleton.PlaySound(1); 
    StartCoroutine(LoadSceneWithSound("MainGame", 0.5f)); 
}

IEnumerator LoadSceneWithSound(string sceneName, float delay)
{
    yield return new WaitForSeconds(delay); 
    SceneManager.LoadScene(sceneName);
}
}
