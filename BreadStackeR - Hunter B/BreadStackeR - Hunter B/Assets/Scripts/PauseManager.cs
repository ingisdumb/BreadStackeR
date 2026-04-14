using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    
    public GameObject pauseCanvas;
    public GameObject alwaysOnCanvas;
    public GameObject settingsCanvas;
    public GameObject confirmationPanel;

    private bool isPaused;

    public void Resume() //resume game
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        alwaysOnCanvas.SetActive(true);
    }

    public void Settings() //settings menu
    {
        settingsCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
    
    public void Quit() //quit to main menu
    {
        confirmationPanel.SetActive(true);
        pauseCanvas.SetActive(false);
    }
    
    public void CancelQuit() //cancel quit to main menu
    {
        confirmationPanel.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void ConfirmQuit()
    {
        SceneManager.LoadScene("Main Menu");
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseCanvas.SetActive(isPaused);
            alwaysOnCanvas.SetActive(!isPaused);
        } 
    }
}
