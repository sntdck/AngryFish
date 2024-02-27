using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject MenuPanel;
    public GameObject boat;
    public GameObject enemy;

    public void Start()
    {
        boat.SetActive(false);
        MenuPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    public void ExitButtonClicked()
    {
           Application.Quit();
    }

    public void StartGame()
    {
        MenuPanel.SetActive(false);
        GamePanel.SetActive(true);
        boat.SetActive(true);
        enemy.SetActive(true);
    }
}
