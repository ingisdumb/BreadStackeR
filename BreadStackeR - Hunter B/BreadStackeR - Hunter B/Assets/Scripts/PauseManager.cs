using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    
    public GameObject pauseCanvas;
    public GameObject alwaysOnCanvas;

    private bool isPaused;
   
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
