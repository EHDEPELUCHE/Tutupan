using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DesafioModeManager : MonoBehaviour
{
    private int score, lives, Puntos;
    public TextMeshProUGUI scoreText, livesText, gameOverText;
    public Button restartButton, exitButton;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start() {
        Puntos = PlayerPrefs.GetInt("Puntos");
        score = 0;
        lives = 3;
    }

    public void UpdateTheScore(int scorePointToAdd) {
        score += scorePointToAdd;
        scoreText.text = score.ToString();
        if (lives == 0) GameOver();
    }
    
    public void UpdateLives() {
        if (isGameOver == false) {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            if (lives == 0) GameOver();
        }
    }

    public void GameOver() {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Puntos", Puntos + score);
    }

    public void RestartTheGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ExitTheGame() {
        
        SceneManager.LoadScene("MenuInicial");
    }
}
