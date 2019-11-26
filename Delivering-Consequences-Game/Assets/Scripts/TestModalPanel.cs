using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalPanel : MonoBehaviour
{
    private ModalPanel modalPanel;

    private UnityAction choice1Event;
    private UnityAction choice2Event;

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();

        choice1Event = new UnityAction(TestChoice1Function);
        choice2Event = new UnityAction(TestChoice2Function);
    }

    public void TestC1C2()
    {
        modalPanel.Choice("Hello! Hello! Hello! Hello! Hello! Hello! Hello! Hello!", "h", "h", choice1Event, choice2Event);
    }

    private void TestChoice1Function()
    {
        Debug.Log("pressed choice 1");
    }

    private void TestChoice2Function()
    {
        Debug.Log("pressed choice 2");
    }
}
