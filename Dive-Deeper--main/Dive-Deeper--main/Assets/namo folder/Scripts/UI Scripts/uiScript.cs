using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiScript : MonoBehaviour
{
    public void LoadScene(int SceneNumber)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNumber);
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void PauseAndResume(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    
   
}
