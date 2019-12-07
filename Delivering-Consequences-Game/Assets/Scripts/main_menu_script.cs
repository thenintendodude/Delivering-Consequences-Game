using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //AudioManager.Get().ToggleMusic(MusicType.outdoor);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        // the below statement will not happen in the unity editor so debug.log to make sure working right now
        Application.Quit();
    }
}
