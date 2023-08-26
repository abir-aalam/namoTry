using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiScript : MonoBehaviour
{
    public GameObject continueBtn;
    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.GetInt("WatchedIntro") == 1)
            {
                continueBtn.SetActive(true);
            }
            else
            {
                continueBtn.SetActive(false);
            }
        }   
    }
    public void LoadScene(int SceneNumber)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNumber);
    }


    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseAndResume(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    
   
}
