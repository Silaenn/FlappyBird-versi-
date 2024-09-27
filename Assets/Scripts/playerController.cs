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
     private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()    
    {
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }
    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump(){
        if (Input.GetMouseButtonDown(0)){
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.singleton.PlaySound(0);
        }
    }

    void PlayerLose(){
        if(score > hiScore){
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        scoreUI.enabled = true;
    }

    void AddScore(){
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "score: " + score.ToString();
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
