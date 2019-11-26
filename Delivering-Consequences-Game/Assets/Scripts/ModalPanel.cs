using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour
{
    public Text Content;
    public Button Choice1;
    public Text Choice1Text;
    public Button Choice2;
    public Text Choice2Text;
    public GameObject ModalPanelObject;

    private static ModalPanel modalPanel;

    // Get reference to modalpanel in game.
    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
            {
                Debug.Log("There needs to be one active Modal Panel object in your game.");
            }
        }

        return modalPanel;
    }

    public void Choice(string content, string choice1Content, string choice2Content, UnityAction choice1Event, UnityAction choice2Event)
    {
        ModalPanelObject.SetActive(true);

        Choice1.onClick.RemoveAllListeners();
        Choice1.onClick.AddListener(choice1Event);
        //Choice1.onClick.AddListener(ClosePanel);

        Choice2.onClick.RemoveAllListeners();
        Choice2.onClick.AddListener(choice2Event);
        //Choice2.onClick.AddListener(ClosePanel);

        this.Content.text = content;
        Choice1Text.text = choice1Content;
        Choice2Text.text = choice2Content;
        Choice1.gameObject.SetActive(true);
        Choice2.gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        ModalPanelObject.SetActive(false);
    }

    // Only displaying text. 
    public void Display(string content)
    {
        //Choice1.gameObject.SetActive(false);
        //Choice2.gameObject.SetActive(false);
        ModalPanelObject.SetActive(true);
        this.Content.text = content;

        Choice1.onClick.RemoveAllListeners();
        Choice2.onClick.RemoveAllListeners();

        Choice1.gameObject.SetActive(false);
        Choice2.gameObject.SetActive(false);
    }
}
