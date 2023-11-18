using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public float jumpHeight = 0.4f;
    public float initialFallSpeed = -0.4f;
    public float fallAcceleration = -0.2f;
    public Text scoreText;
    public Text finalScoreText;
    public GameObject gameOverScreen;

    private int score;
    private float currentFallSpeed;
    private Animation anim;

    void Start() 
    {
        // init score
        score = 0;
        currentFallSpeed = initialFallSpeed;
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1 && Input.GetKeyDown(KeyCode.Space)) {
            anim.Stop();
            // jump
            transform.Translate(0, jumpHeight, 0, Space.World);
            currentFallSpeed = initialFallSpeed; // reset fall speed
            transform.rotation = Quaternion.Euler(Vector3.forward * 20);
            anim.Play("BirdUp2Flat");
        } else {
            // fall
            Debug.Log("CurrentFallSpeed: " + currentFallSpeed); // TODO: Debug acceleration
            transform.Translate(0, currentFallSpeed * Time.deltaTime, 0, Space.World);
            currentFallSpeed += fallAcceleration * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * -30);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Tube(Clone)" || collision.gameObject.name == "Floor") {
            // show game over
            Debug.Log("Game Over");
            scoreText.enabled = false;
            gameOverScreen.SetActive(true);
            finalScoreText.text = "Final Score: " + score;
            Time.timeScale = 0; // pauses game
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "ScoreCollision") {
            score ++;
            scoreText.text = "Score: " + score;
        }
    }

    public void RestartGame() {
        scoreText.enabled = true;
        Time.timeScale = 1;// resumes
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
