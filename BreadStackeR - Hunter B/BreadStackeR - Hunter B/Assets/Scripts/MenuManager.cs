using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionsCanvas;
    public GameObject controlsCanvas;
    public GameObject creditsCanvas;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game!");
    }
    
    public void BackToMenu()
    {
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }
    public void DisplayControls()
    {
        controlsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void Credits()
    {
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    public void backFromCredits()
    {
        menuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }
}