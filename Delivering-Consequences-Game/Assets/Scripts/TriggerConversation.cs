using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerConversation : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    private bool TriggerPressed = false;

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
            if(NPC.GetComponent<PlayerConversation>() != null)// && TriggerPressed)
            {
                //TODO: GET SCRIPT PUSHDETECTION AND DISABLE IT FOR THE CURRENT NPC 
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

            //DISABLE WITHIN RADIUS HERE
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))// && within radius of NPC)
        {
            TriggerPressed = true;
        }
    }

    void LateUpdate()
    {
        // Snap trigger radius to its NPC.
        this.transform.position = NPC.transform.position;
    }
}
