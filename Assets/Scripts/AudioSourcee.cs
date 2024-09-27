using UnityEngine;

public class AudioSourcee : MonoBehaviour
{

    public static AudioSourcee singleton;
    public AudioClip[] clips;
    AudioSource audioSource;

    private void Awake() {
        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

   public void PlaySound(int clipIndex){
        audioSource.PlayOneShot(clips[clipIndex]);
    }

}
