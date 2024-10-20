using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGame : MonoBehaviour
{

 public static SceneGame singleton;

 private void Awake() {
    singleton = this;
 }

public void StartGame()
{
    AudioSourcee.singleton.PlaySound(1); 
    StartCoroutine(LoadSceneWithSound("MainGame", 0.5f)); 
}
public void MainSkin()
{
    AudioSourcee.singleton.PlaySound(1); 
    StartCoroutine(LoadSceneWithSound("MainSkin", 0.5f));
}

public IEnumerator LoadSceneWithSound(string sceneName, float delay)
{
    yield return new WaitForSeconds(delay); 
    SceneManager.LoadScene(sceneName);
}
}
