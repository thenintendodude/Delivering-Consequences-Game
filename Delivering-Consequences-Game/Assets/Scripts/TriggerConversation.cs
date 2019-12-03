using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerConversation : MonoBehaviour
{
    [SerializeField] private GameObject NPC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Trigger Conversation :)");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Can No Longer Trigger Conversation :(");
        }
    }

    // Update after movement has been settled
    void LateUpdate()
    {
        this.transform.position = NPC.transform.position; 
    }
}
