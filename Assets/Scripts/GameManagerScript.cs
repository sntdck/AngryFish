using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject winGameUI;

    public GameObject boat;
    public GameObject enemy;
    public GameObject gameCanvas;
    public GameObject pauseUI;
    public GameObject OptionsUI;
    public GameObject MainMenu;
    public Button backToPause;

    public BoatController boatController;
    public Text distance;
    public Text distanceGO;

    void Update()
    {
       
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        gameCanvas.SetActive(false);
        boatController.speed = 0f;
        boatController.PauseAudio();
        enemy.SetActive(false);
        boat.SetActive(false);
        distanceGO.text = "Distance: " + boatController.GetDistanceTraveled().ToString("F2") + " m";
    }
    
    public void restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        pauseUI.SetActive(false);
        MainMenu.SetActive(true); 
    }

    public void winGame()
    {
        gameCanvas.SetActive(false);
        winGameUI.SetActive(true);
        boatController.speed = 0f;
        boatController.PauseAudio();
        enemy.SetActive(false);
        distance.text = "Distance: " + boatController.GetDistanceTraveled().ToString("F2") + " m";
    }
    public void exitGame()
    {
        Application.Quit();
    }

    public void turnOptions()
    {
        pauseUI.SetActive(false);
        OptionsUI.SetActive(true);
    }

    public void backPause()
    {
        if( backToPause != null)
        {
            OptionsUI.SetActive(false);
            pauseUI.SetActive(true);
        }
    }

}
