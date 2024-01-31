using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public Image lifeImage1;
    public Image lifeImage2;
    public Image lifeImage3;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        Debug.Log("Clicking on buton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void loseLife(int lifeCount)
    {
        if (lifeCount == 3)
        {
            Destroy(lifeImage1.gameObject);
            lifeCount--;
        }
        else if (lifeCount == 2)
        {
            Destroy(lifeImage2.gameObject);
            lifeCount--;
        }
        else if (lifeCount == 1)
        {
            Destroy(lifeImage3.gameObject);
            lifeCount--;
        }
    }
}