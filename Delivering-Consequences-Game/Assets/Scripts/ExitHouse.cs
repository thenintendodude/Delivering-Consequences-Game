using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject RoomCamera;

    [SerializeField] private Vector3 OutdoorSpawn;
    [SerializeField] private GameObject Player;

    private AudioManager AudioManager;
    private void Start()
    {
        AudioManager = AudioManager.Get();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Switching Cameras To Outdoor");
            this.RoomCamera.SetActive(false);
            this.MainCamera.SetActive(true);
            Player.transform.position = this.OutdoorSpawn;
            AudioManager.ToggleMusic(MusicType.outdoor);
            AudioManager.TriggerSoundEffect(SoundEffect.closeDoor);
        }
    }
}
