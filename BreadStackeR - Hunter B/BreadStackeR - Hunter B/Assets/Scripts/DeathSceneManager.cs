using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneManager : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("Main Warehouse");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
