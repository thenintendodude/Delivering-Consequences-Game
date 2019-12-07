using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackstoryScene : MonoBehaviour
{
    public void ContinueToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Get().ToggleMusic(MusicType.outdoor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
