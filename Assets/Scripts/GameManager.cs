using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public Button pauseButton;
    public Button continueButton;
    public Button restartButton;
    public Button mainMenuButton;

    private void Start()
    {
        isGameActive = true;
    }

   void StartGame()
   {
       isGameActive = true;
       Time.timeScale = 1;
       pauseButton.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true);
   }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        StartGame();
        pauseButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
