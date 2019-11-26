using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conversation;

namespace Conversation
{
    public class PlayerConversation : MonoBehaviour
    {
        private bool IsTalking = false;
        private TextNode TextObject;
        //private string[] TextScreens;
        private List<string> TextScreens;
        private int TextIndex;
        private bool DisplayingLastTextScreen = false;
        private string PlayerName;
        private GameObject Npc;
        private int NumCharsPerLine = 285;

        private ConversationContainer MyConversations;

        private ModalPanel modalPanel;

        private void Awake()
        {
            modalPanel = ModalPanel.Instance();
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
            /*if(Input.GetButtonDown("Jump"))
            {
                StartTalking();
            }*/

            if(!IsTalking && Input.GetButtonDown("Jump"))
            { //&& physics.npccollisionoccurred()) {
                //Player.immobilize();
                StartTalking();
            }
            else if(IsTalking && Input.GetButtonDown("Jump"))
            {
                DisplayNextTextScreen();
            }
            else if(DisplayingLastTextScreen && Input.GetButtonDown("Jump") && TextObject.choice1 == "") //means they do not have any choices available on screen
            {
                DisplayingLastTextScreen = false;

                if(IsConversationOver())
                {
                    IsTalking = false;
                    //Npc.conversationID = TextNode.NextConversation
                }
                else // Else we know they just pressed Jump and there is still more to the conversation. 
                {
                    GetAndStartDisplayingText(TextObject.choice1id);
                }
            }
            /*else if(DisplayingLastTextScreen && (TextObject.character == "name" && Input.GetButtonDown("Jump") || TextObject.character == "NPCNAME" /*Npc.name*/ /*&&
                (Input.GetButtonDown("Jump") && IsConversationOver())))
            {
                DisplayingLastTextScreen = false;

                if(IsConversationOver())
                {
                    IsTalking = false;
                    //Npc.conversationID = TextNode.NextConversation
                    GetAndStartDisplayingText(TextObject.choice1id);
                }
            }*/
        }

        private bool IsConversationOver()
        {
            return (TextObject.choice1id == "");
        }

        private void StartTalking()
        {
            this.IsTalking = true;
            //this.Npc = Physics.GetInteractionNPC();
            GetAndStartDisplayingText("root1"); //"1" should be this.Npc.conversationID
        }

        private void GetAndStartDisplayingText(string conversationID)
        {
            TextObject = MyConversations.GetTextNode(conversationID);
            TextObject.script = "Paragraphs are the building blocks of papers. Many students define paragraphs in terms of length: a paragraph is a group of at least five sentences, a paragraph is half a page long, etc. In reality, though, the unity and coherence of ideas among sentences is what constitutes a paragraph. A paragraph is defined as “a group of sentences or a single sentence that forms a unit” (Lunsford and Connors 116). Length and appearance do not determine whether a section in a paper is a paragraph. For instance, in some styles of writing, particularly journalistic styles, a paragraph can be just one sentence long. Ultimately, a paragraph is a sentence or group of sentences that support one main idea. In this handout, we will refer to this as the “controlling idea,” because it controls what happens in the rest of the paragraph.";
            Parse(); //parse textObject for each screen size and put into textScreens
            TextIndex = 0;
            DisplayNextTextScreen();
        }

        //each screen can only hold up to 84 characters per line x 4 lines = 336 characters
        private void Parse()
        {
            TextScreens = new List<string>();
            string TextToParse = TextObject.script;
            int TextToParseIndex = 0;

            if(TextToParse.Length < NumCharsPerLine)
            {
                TextScreens.Add(TextToParse);
            } else
            {
                while(TextToParse.Substring(TextToParseIndex).Length > NumCharsPerLine)
                {
                    TextScreens.Add(TextToParse.Substring(TextToParseIndex, NumCharsPerLine));
                    TextToParseIndex += NumCharsPerLine;
                }

                if(TextToParseIndex < TextToParse.Length - 1)
                {
                    TextScreens.Add(TextToParse.Substring(TextToParseIndex));
                }
            }

        }

        private void DisplayNextTextScreen()
        {
            Display(TextScreens[TextIndex]);
            if (TextIndex == TextScreens.Count - 1)
            {
                DisplayingLastTextScreen = true;
                if(TextObject.choice1 != "") //there are choices to display
                {
                    DisplayChoices();
                }
            }
            TextIndex++;
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
            Debug.Log("choice1");
            //GetAndStartDisplayingText(TextObject.choice1id);
        }

        private void Choice2Function()
        {
            //GetAndStartDisplayingText(TextObject.choice2id);
        }
    }
}
