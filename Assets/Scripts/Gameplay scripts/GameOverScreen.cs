using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMPro.TextMeshProUGUI levelText;
    public TMPro.TextMeshProUGUI timeText;

    private void Update()
    {
        timeText.text = Timer.timerText.text;
        levelText.text = GameManager.scoreText.text;
    }

    public void TryAgainButton()
    {
        print(SceneManager.GetActiveScene().ToString());

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.score = 0;
        gameObject.SetActive(false);
        
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        GameManager.score = 0;
        gameObject.SetActive(false);
        SceneManager.LoadScene(0); 
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void Setup(int level, float time)
    {
        gameObject.SetActive(true);
        
    }

}
