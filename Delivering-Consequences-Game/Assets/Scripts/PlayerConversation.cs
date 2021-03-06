﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conversation;
using UnityEngine.SceneManagement;

public class PlayerConversation : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    private PlayerMovement PlayerMovement;
    private GameObject player;

    private bool IsTalking = false;
    private TextNode TextObject;
    private List<string> TextScreens;
    private int TextIndex;
    private bool DisplayingLastTextScreen = false;
    private int NumCharsPerLine = 300;
    public string NextConversation;
    private bool WithinRadius = false;

    private ConversationContainer MyConversations;

    private ModalPanel modalPanel;

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();
        PlayerMovement =
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        MyConversations = new ConversationContainer();
        MyConversations.LoadJsonData("Manuscripts/villageManuscript.json");
    }

    // Update is called once per frame
    void Update()
    {
        // This only happens when we are able to move on in the game and the empathy bar is full. 
        if(NPC.GetComponent<UpdateBars>() != null && NPC.GetComponent<UpdateBars>().isEmpathyFull() && NPC.gameObject.tag != "Fie")
        {
            NextConversation = "end";
        }
        else if(NPC.GetComponent<UpdateBars>() != null && NPC.GetComponent<UpdateBars>().isEmpathyFull() && NPC.gameObject.tag == "Fie")
        {
            NextConversation = "winGame";
        }

        // We always want Fie to have the first conversation and we do not need the player to press space; we always want it to happen.
        if (!IsTalking && WithinRadius && NPC.name == "Fie Ronndly" && !player.GetComponent<PlayerInteraction>().isTalkingToNPC() && NextConversation == "AwakenInTown0")
        {
            AudioManager.Get().TriggerSoundEffect(SoundEffect.uiConfirmation);
            NPC.GetComponent<InteractionPanel>().setInteractionPanel(false);
            PlayerMovement.AllowMovement(false);
            player.GetComponent<PlayerInteraction>().setTalkingToNPC(true);
            StartTalking();
        }
        if (!IsTalking && WithinRadius && Input.GetButtonDown("Jump") && !player.GetComponent<PlayerInteraction>().isTalkingToNPC())
        {
            AudioManager.Get().TriggerSoundEffect(SoundEffect.uiConfirmation);
            NPC.GetComponent<InteractionPanel>().setInteractionPanel(false);
            PlayerMovement.AllowMovement(false);
            player.GetComponent<PlayerInteraction>().setTalkingToNPC(true);
            StartTalking();
        }
        else if (IsTalking && Input.GetKeyDown(KeyCode.C) && !DisplayingLastTextScreen)
        {
            DisplayNextTextScreen();
        }
        else if (DisplayingLastTextScreen && Input.GetKeyDown(KeyCode.C) && TextObject.choice1 == "") // Means they do not have any choices available on screen.
        {
            DisplayingLastTextScreen = false;

            if (IsConversationOver())
            {
                IsTalking = false;
                player.GetComponent<PlayerInteraction>().setTalkingToNPC(false);
                NPC.GetComponent<InteractionPanel>().setInteractionPanel(true);
                PlayerMovement.AllowMovement(true);
                modalPanel.ClosePanel();
            }
            else // Else we know they just pressed Jump and there is still more to the conversation. 
            {
                GetAndStartDisplayingText(TextObject.choice1id);
            }
        }
    }

    public void setWithinRadius(bool b)
    {
        WithinRadius = b;
    }

    private bool IsConversationOver()
    {
        return (TextObject.choice1id == "");
    }

    private void StartTalking()
    {
        this.IsTalking = true;
        GetAndStartDisplayingText(NextConversation); 
    }

    private void GetAndStartDisplayingText(string conversationID)
    {
        TextObject = MyConversations.GetTextNode(conversationID);
        Parse(); // Parse textObject for each screen size and put into textScreens.
        TextIndex = 0;
        DisplayNextTextScreen();
    }

    private void Parse()
    {
        TextScreens = new List<string>();
        string TextToParse = TextObject.script;
        int TextToParseIndex = 0;

        if (TextToParse.Length < NumCharsPerLine)
        {
            if (TextToParseIndex == 0)
            {
                TextScreens.Add(TextObject.character + ": " + TextToParse);
            }
            else
            {
                TextScreens.Add(TextToParse);
            }
        }
        else
        {
            while (TextToParse.Substring(TextToParseIndex).Length > NumCharsPerLine)
            {
                if (TextToParseIndex == 0)
                {
                    TextScreens.Add(TextObject.character + ": " + TextToParse.Substring(TextToParseIndex, NumCharsPerLine));
                }
                else
                {
                    TextScreens.Add(TextToParse.Substring(TextToParseIndex, NumCharsPerLine));
                }
                    
                TextToParseIndex += NumCharsPerLine;
            }

            if (TextToParseIndex < TextToParse.Length - 1)
            {
                TextScreens.Add(TextToParse.Substring(TextToParseIndex));
            }
        }

    }

    private void DisplayNextTextScreen()
    {
        if (TextIndex < TextScreens.Count)
        {
            Display(TextScreens[TextIndex]);
            if (TextIndex == TextScreens.Count - 1)
            {
                DisplayingLastTextScreen = true;
                if (TextObject.choice1 != "") // There are choices to display.
                {
                    DisplayChoices();
                }
                NextConversation = TextObject.nextConversation;
            }
            TextIndex++;
        }
    }

    private void Display(string textToDisplay)
    {
        modalPanel.Display(textToDisplay);
    }

    private void DisplayChoices()
    {
        modalPanel.Choice(TextScreens[TextIndex], TextObject.choice1, TextObject.choice2, Choice1Function, Choice2Function);
    }

    // These get invoked depending on which choice the player chooses, if applicable. 
    private void Choice1Function()
    {
        if (NPC.GetComponent<UpdateBars>() != null)
        {
            NPC.GetComponent<UpdateBars>().updateEmpathy(TextObject.c1e);
            NPC.GetComponent<UpdateBars>().updatePower(TextObject.c1p);
            NPC.GetComponent<UpdateBars>().updateCharisma(TextObject.c1c);
            NPC.GetComponent<UpdateBars>().updateStrategy(TextObject.c1s);
        }
        if (TextObject.choice1id != "")
        {
            GetAndStartDisplayingText(TextObject.choice1id);
        }
        else
        {
            // This is only when you want to restart the game!
            if(TextObject.choice1 == "Restart! I need more empathy.")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            PlayerMovement.AllowMovement(true);
            IsTalking = false;
            player.GetComponent<PlayerInteraction>().setTalkingToNPC(false);
            NPC.GetComponent<InteractionPanel>().setInteractionPanel(true);
            modalPanel.ClosePanel();
        }
    }

    private void Choice2Function()
    {
        if (NPC.GetComponent<UpdateBars>() != null)
        {
            NPC.GetComponent<UpdateBars>().updateEmpathy(TextObject.c2e);
            NPC.GetComponent<UpdateBars>().updatePower(TextObject.c2p);
            NPC.GetComponent<UpdateBars>().updateCharisma(TextObject.c2c);
            NPC.GetComponent<UpdateBars>().updateStrategy(TextObject.c2s);
        }
        if (TextObject.choice2id != "")
        {
            GetAndStartDisplayingText(TextObject.choice2id);
        }
        else
        {
            PlayerMovement.AllowMovement(true);
            IsTalking = false;
            player.GetComponent<PlayerInteraction>().setTalkingToNPC(false);
            NPC.GetComponent<InteractionPanel>().setInteractionPanel(true);
            modalPanel.ClosePanel();
        }
    }
}
