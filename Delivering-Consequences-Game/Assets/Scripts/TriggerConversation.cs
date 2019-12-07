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
            // Trigger behavior that happens when Player within radius of NPC. 
            if(NPC.GetComponent<VillagerMovement>() != null)
            {
                NPC.GetComponent<VillagerMovement>().setFacePlayer(true);
            }
            if(NPC.GetComponent<PlayerConversation>() != null)
            {
                NPC.GetComponent<PushDetection>().enabled = false;
                NPC.GetComponent<PlayerConversation>().setWithinRadius(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Can No Longer Trigger Conversation :(");
            // Trigger behavior that happens when Player is outside of radius of NPC. 
            if (NPC.GetComponent<VillagerMovement>() != null)
            {
                NPC.GetComponent<VillagerMovement>().setFacePlayer(false);
            }

            if (NPC.GetComponent<PlayerConversation>() != null)
            {
                NPC.GetComponent<PushDetection>().enabled = true;
                NPC.GetComponent<PlayerConversation>().setWithinRadius(false);
            }
        }
    }

    void LateUpdate()
    {
        // Snap trigger radius to its NPC.
        this.transform.position = NPC.transform.position;
    }
}
