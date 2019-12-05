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
            //Trigger Stop in Movement, Start Movement to Rotate and Face Player 
            if(NPC.GetComponent<VillagerMovement>() != null)
            {
                NPC.GetComponent<VillagerMovement>().FacePlayer = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Can No Longer Trigger Conversation :(");
            NPC.GetComponent<VillagerMovement>().FacePlayer = false;
        }
    }

    // Update after movement has been settled
    void LateUpdate()
    {
        this.transform.position = NPC.transform.position; 
    }
}
