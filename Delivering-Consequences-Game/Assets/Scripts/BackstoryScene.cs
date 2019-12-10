using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackstoryScene : MonoBehaviour
{
    public void ContinueToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        // The below statement will not happen in the unity editor so debug.log to make sure working right now.
        Application.Quit();
    }
}
