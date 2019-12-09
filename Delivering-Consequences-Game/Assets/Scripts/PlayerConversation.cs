using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conversation;

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
    private int NumCharsPerLine = 550;
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
        //for testing getting a text object
        MyConversations = new ConversationContainer();
        MyConversations.LoadJsonData("Manuscripts/villageManuscript.json");
    }

    // Update is called once per frame
    void Update()
    {
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
        if (TextObject.choice1id != "")
        {
            GetAndStartDisplayingText(TextObject.choice1id);
        }
        else
        {
            NPC.GetComponent<InteractionPanel>().setInteractionPanel(true);
            modalPanel.ClosePanel();
        }
        if (NPC.GetComponent<UpdateBars>() != null)
        {
            NPC.GetComponent<UpdateBars>().updateEmpathy(10); // make these based off the text node values! 
            NPC.GetComponent<UpdateBars>().updatePower(10);
            NPC.GetComponent<UpdateBars>().updateCharisma(10);
            NPC.GetComponent<UpdateBars>().updateStrategy(10);
        }
    }

    private void Choice2Function()
    {
        if (TextObject.choice2id != "")
        {
            GetAndStartDisplayingText(TextObject.choice2id);
        }
        else
        {
            NPC.GetComponent<InteractionPanel>().setInteractionPanel(true);
            modalPanel.ClosePanel();
        }
        if (NPC.GetComponent<UpdateBars>() != null)
        {
            NPC.GetComponent<UpdateBars>().updateEmpathy(10); // make these based off the text node values! 
            NPC.GetComponent<UpdateBars>().updatePower(10);
            NPC.GetComponent<UpdateBars>().updateCharisma(10);
            NPC.GetComponent<UpdateBars>().updateStrategy(10);
        }
    }
}
