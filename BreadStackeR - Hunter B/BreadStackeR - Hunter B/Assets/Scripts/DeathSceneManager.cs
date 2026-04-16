using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
