using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPanel : MonoBehaviour
{
    public GameObject interactionPanel;

    public bool isIPActive()
    {
        if(interactionPanel.active)
        {
            return true;
        }
        return false;
    }

    public void setInteractionPanel(bool b)
    {
        if(b)
        {
            interactionPanel.SetActive(true);
        }
        else
        {
            interactionPanel.SetActive(false);
        }
    }
}
