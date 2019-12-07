using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPanel : MonoBehaviour
{
    public GameObject interactionPanel;
    private bool WithinRadius = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (WithinRadius)
        {
            Debug.Log("into within radius");
            interactionPanel.SetActive(true);
        }
        else
        {
        //    Debug.Log("out of within radius");
            interactionPanel.SetActive(false);
        }*/
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

    /*public void setWithinRadius(bool b)
    {
        WithinRadius = b;
    }*/
}
