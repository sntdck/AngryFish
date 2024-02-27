using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public GameObject playGame;
    public GameObject pauseGame;
    public GameObject boat;
    public Button pauseButton;

    public BoatController boatController;
    void Start()
    {
        
    }

    public void PauseGame()
    {
        if (pauseButton != null)
        {
            Time.timeScale = 0f;

            playGame.SetActive(false);
            pauseGame.SetActive(true);
            boatController.speed = 0f;
            boatController.PauseAudio();
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        playGame.SetActive(true);
        pauseGame.SetActive(false);
        boatController.speed = 10f;
        boatController.ResumeAudio();
    }
}
