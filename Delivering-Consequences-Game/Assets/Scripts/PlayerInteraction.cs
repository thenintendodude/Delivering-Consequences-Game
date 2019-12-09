using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool talkingToNPC = false;

    public bool isTalkingToNPC()
    {
        return talkingToNPC;
    }

    public void setTalkingToNPC(bool b)
    {
        talkingToNPC = b;
    }
}
