using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// This ensures that the Audio object persists between scenes, so that the
/// audio doesn't restart every time the scene changes.
public class BackstoryAudioManager : MonoBehaviour
{
    public static BackstoryAudioManager Instance { get; private set; } = null;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            this.GetComponent<AudioSource>().Play();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            // Stop playing backstory music once we finish the backstory scenes
            Destroy(this.gameObject);
        }
    }
}
