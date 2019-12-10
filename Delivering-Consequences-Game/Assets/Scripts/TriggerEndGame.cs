using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEndGame : MonoBehaviour
{
    [SerializeField] private GameObject endPoint;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void LateUpdate()
    {
        // Snap trigger radius to its NPC.
        this.transform.position = endPoint.transform.position;
    }
}
