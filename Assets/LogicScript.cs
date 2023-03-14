using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    [ContextMenu("Soma Ponto")]
    public void addScore(int scoreToAdd) {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    
    [ContextMenu("Get Score")] 
    public int getScore() {
        return playerScore;
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }

    [ContextMenu("Quit Game")] 
    public void quitGame() {
        Application.Quit();
    }
}

