using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Click detected!");
        SceneManager.LoadScene("BuyScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
