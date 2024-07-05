using System.Collections;
using UnityEngine;
using TMPro;

public class Jawab : MonoBehaviour {
    public GameObject feed_benar, feed_salah;
    public TextMeshProUGUI scoreText; // Reference to the score TextMeshPro component
    private bool hasAnswered = false; // Flag to check if the question has been answered

    void Start() {
        // Check if scoreText is assigned
        if (scoreText == null) {
            Debug.LogError("Score Text is not assigned in the Inspector");
            return;
        }
        
        // Initialize the score display
        
        UpdateScore();
    }

    public void jawaban(bool jawab) {
        if (!hasAnswered) {
            hasAnswered = true; // Mark the question as answered
            StartCoroutine(ShowFeedback(jawab));
        }
    }

    private IEnumerator ShowFeedback(bool jawab) {
        if (jawab) {
            feed_benar.SetActive(true);
            double score = PlayerPrefs.GetFloat("score", 0) + 5.5;
            PlayerPrefs.SetFloat("score", (float)score); // PlayerPrefs does not support double, so cast to float
            UpdateScore(); // Update the score display
        } else {
            feed_salah.SetActive(true);
        }

        // Wait for a short period to display feedback
        yield return new WaitForSeconds(1.5f);

        // Hide feedback after the wait
        feed_benar.SetActive(false);
        feed_salah.SetActive(false);

        // Deactivate current question and activate the next one
        gameObject.SetActive(false);
        Transform nextQuestion = transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1);
        if (nextQuestion != null) {
            nextQuestion.gameObject.SetActive(true);
        } else {
            CheckHighScore();
        }
    }

    void UpdateScore() {
        if (scoreText == null) {
            Debug.LogError("Score Text is not assigned in the Inspector");
            return;
        }
        
        double score = (double)PlayerPrefs.GetFloat("score", 0);
        scoreText.text = score.ToString("F1"); // Display the score with one decimal place
    }

    void CheckHighScore() {
        double score = (double)PlayerPrefs.GetFloat("score", 0);
        double highScore = (double)PlayerPrefs.GetFloat("highscore", 0);

        if (score > highScore) {
            PlayerPrefs.SetFloat("highscore", (float)score);
            UpdateHighScore();
        }
    }

    void UpdateHighScore() {
        double highScore = (double)PlayerPrefs.GetFloat("highscore", 0);
        // Assuming you have a TextMeshProUGUI component to display the high score
        // highScoreText.text = "High Score: " + highScore.ToString("F1");
    }

    void ResetScore() {
        PlayerPrefs.SetFloat("score", 0);
    }

    void Update() {
        // Update method if needed
    }
}
