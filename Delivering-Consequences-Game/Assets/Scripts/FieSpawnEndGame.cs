using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieSpawnEndGame : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject NPCSpawnPoint;
    [SerializeField] private GameObject villageDecor;

    // Update is called once per frame
    void Update()
    {
        if (NPC.GetComponent<UpdateBars>() != null && NPC.GetComponent<UpdateBars>().isEmpathyFull() && NPC.transform.position != NPCSpawnPoint.transform.position)
        {
            NPC.transform.position = NPCSpawnPoint.transform.position;
            villageDecor.SetActive(false);
        }
    }
}
