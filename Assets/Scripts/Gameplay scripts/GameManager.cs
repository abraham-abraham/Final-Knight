using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int endGameScore = -20;

    public static int level = 1;
    public static int difficultyStep = 25;

    public static TMPro.TextMeshProUGUI scoreText;

    public static TMPro.TextMeshProUGUI mobText;

    public static int score;

    GameObject player;


    public GameObject gameOverScreen;
    public GameObject mobSpawner;

   // public GameObject mobSpawnerObject;

    public bool isMobHere;

    public void EndGame()
    {
        //PauseControl.PauseGame();
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        // GameObject.Find("Game Over Background").gameObject.SetActive(true);
        player.SetActive(false);
    }

    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        scoreText = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();

        
      //  mobText = GameObject.Find("Mob").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + score.ToString();
       // print("Score " + score.ToString());

        if(score > 20 && score < 40)
        {
            level =2;
        }

        if(score > 40 && score < 100)
        {
            level = 3;
        }
        
        if(score > 100 && score < 250)
        {
            level =4;
        }

        if(score > 250 && score < 500)
        {
            level = 5;
        }

        if (score <= endGameScore)
        {

            EndGame();
        }

        if (!isMobHere)
        {
            isMobHere = true;
            Invoke("ActivateMobSpawner", 60);

        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    print("esc");
        //    PauseControl.PauseGame();
        //}
    }

    void ActivateMobSpawner()
    {
        if(mobSpawner != false)
        mobSpawner.gameObject.SetActive(true);
        isMobHere = false;
        if(mobText != null)
        mobText.gameObject.SetActive(true);

    }

   void DeActivateMobSpawner()
    {
        mobSpawner.gameObject.SetActive(false);
        Invoke("DeActivateMobSpawner", 20);
        isMobHere = true;
        if(mobText != null)
        mobText.gameObject.SetActive(false);
    }
   
}





public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public static void PauseGame()
    {
        if (gameIsPaused)
        {
            print("gameispaused");
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            print("gamenotpaused");
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
}
