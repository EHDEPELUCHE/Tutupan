using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DesafioModeManager : MonoBehaviour
{
    private int score;
    private int lives;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button exitButton;

    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTheScore(int scorePointToAdd)
    {
        score += scorePointToAdd;
        scoreText.text = score.ToString();

        if (lives == 0)
        {
            GameOver();
        }
    }
    
    public void UpdateLives()
    {
        if (isGameOver == false)
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ExitTheGame()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
