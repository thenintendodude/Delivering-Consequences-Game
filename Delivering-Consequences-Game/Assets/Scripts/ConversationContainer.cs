using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Conversation
{
    public class ConversationContainer
    {
        Dictionary<string, TextNode> LoadedConversations;

        private void Start()
        {
        }

        // Loads manuscripts from the Json file they are stored in. 
        // (credit: Zee helped with organization ideas and loading Json data)
        public void LoadJsonData(string jsonFile)
        {
            string fPath = Path.Combine(Application.dataPath, jsonFile);

            if (File.Exists(fPath))
            {
                // Read JSON file
                string JSONData = File.ReadAllText(fPath);

                // Create array of TextNode objects
                var arrayFormatted = Helpers.JsonHelper.getNodeArray<TextNode>(JSONData);

                // Convert array to dictionary.
                ArrayToDict(arrayFormatted);
            }
            else
            {
                Debug.Log("Conversation File does not exist");
            }
        }

        // Converts json array into a dictionary 
        private void ArrayToDict(TextNode[] textArray)
        {
            LoadedConversations = new Dictionary<string, TextNode>();
            
            foreach (TextNode node in textArray)
            {
                LoadedConversations.Add(node.id, node);
            }
        }

        // Retrieves desired text node.
        public TextNode GetTextNode(string nodeID)
        {
            return LoadedConversations[nodeID];
        }

    }

    [System.Serializable]
    public class TextNode
    {
        public string id;
        public string character;
        public string script;
        public string choice1;
        public string choice2;
        public string choice1id;
        public string choice2id;
        public string nextConversation;
        public string c1e;
        public string c1p;
        public string c1c;
        public string c1s;
    }
}


