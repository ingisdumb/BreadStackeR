using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionsCanvas;

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
}