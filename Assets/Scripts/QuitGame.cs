using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{
    public void QuitGames(){
          #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Berhenti play mode di editor
        #else
        Application.Quit(); // Keluar saat build
        #endif
    }
}
