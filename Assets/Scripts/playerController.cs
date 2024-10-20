using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public GameObject loseScreen;
    public int score, hiScore;
    public Text scoreUI, hiScoreUI;
    string HISCORE = "HISCORE";

    bool lose = false;
     private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()    
    {
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

    void Update()
    {
        PlayerJump();
    }

    void PlayerJump(){
        if (Input.GetMouseButtonDown(0) && !lose){
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.singleton.PlaySound(0);
        }
    }

    void PlayerLose(){
        lose = true;
        if(score > hiScore){
          lose = false;
          scoreUI.enabled = false;
          hiScore = score;  
          PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        AudioManager.singleton.PlaySound(1);
        hiScoreUI.text = "HiScore: " + hiScore.ToString();
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

   public void RestartGame(){
    AudioManager.singleton.PlaySound(3);
    StartCoroutine(RestartAfterDelay(0.5f));  // Tambahkan delay sebelum reload
}

    IEnumerator RestartAfterDelay(float delay){
    yield return new WaitForSecondsRealtime(delay); // Tunggu beberapa waktu sebelum memuat ulang scene
    Time.timeScale = 1;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    scoreUI.enabled = true;
    lose = false;
}

    void AddScore(){
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "score: " + score.ToString();
    }

    public void BackToMenu(){
    AudioManager.singleton.PlaySound(3);
    StartCoroutine(BackToMenuAfterDelay(0.5f));  // Tambahkan delay sebelum ke menu
}

    IEnumerator BackToMenuAfterDelay(float delay){
    yield return new WaitForSecondsRealtime(delay); // Tunggu beberapa waktu sebelum memuat ulang scene
    Time.timeScale = 1;
    SceneManager.LoadScene("MainMenu");
}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Obstacle")){
          PlayerLose();
    }
}
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("score")){
            AddScore();
        }
    }
}
