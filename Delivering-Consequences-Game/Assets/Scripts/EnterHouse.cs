using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject RoomCamera;

    [SerializeField] private Vector3 RoomSpawn;
    [SerializeField] private GameObject Player;

    private AudioManager AudioManager;
    private void Start()
    {
        AudioManager = GameObject.FindWithTag("audio").GetComponent<AudioManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Switching Cameras to Indoor");
            this.MainCamera.SetActive(false);
            this.RoomCamera.SetActive(true);
            Player.transform.position = RoomSpawn;
            AudioManager.ToggleMusic(AudioManager.MusicType.indoor);
        }
    }
}
