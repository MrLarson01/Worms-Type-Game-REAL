using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Play;


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
      
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
