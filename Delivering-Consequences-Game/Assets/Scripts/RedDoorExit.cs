using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoorExit : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject RoomCamera;

    [SerializeField] private Vector3 OutdoorSpawn;
    [SerializeField] private GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered Doormat");
        //Player enters door of red house
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Switching Cameras To Outdoor");
            this.RoomCamera.SetActive(false);
            this.MainCamera.SetActive(true);
            Player.transform.position = this.OutdoorSpawn;
        }
    }
}
