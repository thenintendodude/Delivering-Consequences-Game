using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoorEntry : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject RoomCamera;

    [SerializeField] private Vector3 RoomSpawn;
    [SerializeField] private GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered Door");
        //Player enters door of red house
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Switching Cameras");
            this.MainCamera.SetActive(false);
            this.RoomCamera.SetActive(true);
            Player.transform.position = RoomSpawn;
        }
    }
}
