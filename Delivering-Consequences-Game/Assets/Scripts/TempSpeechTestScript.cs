using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conversation;

public class TempSpeechTestScript : MonoBehaviour
{
    private ConversationContainer MyConversations;
    private float TimePassed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        MyConversations = new ConversationContainer();
        MyConversations.LoadJsonData("Manuscripts/villageManuscript.json");
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;

        if(TimePassed > 1.5f)
        {
            TimePassed -= 100.0f;
            TextNode myNode = MyConversations.GetTextNode("root1");
            Debug.Log(myNode.character + ": " + myNode.script);
        }
    }
}
