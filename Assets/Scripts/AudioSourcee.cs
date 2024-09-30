using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioSourcee : MonoBehaviour
{

    public static AudioSourcee singleton;
    public AudioClip[] clips;
    AudioSource audioSource;

    private void Awake() {

        if (singleton != null) {
            Destroy(gameObject); 
            return;
        }

        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

     private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "MainGame") {
            audioSource.Stop();
        } else {
            PlaySound(0); 
        }
    }

   public void PlaySound(int clipIndex){
        if(clipIndex == 0){
            if(audioSource.isPlaying){
                return;
            }
            audioSource.clip = clips[clipIndex];
            audioSource.Play();
            DontDestroyOnLoad(gameObject);

        } else {
        audioSource.PlayOneShot(clips[clipIndex]);
        }
    }

}
