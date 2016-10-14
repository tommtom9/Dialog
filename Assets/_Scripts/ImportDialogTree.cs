using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class ImportDialogTree : MonoBehaviour {

    [SerializeField]
    TextAsset xmldocument;

    [SerializeField]
    ConvertToDialog reciever;

    XmlDocument xml = new XmlDocument();

    List<string> conversationText = new List<string>();
    List<string> responsesText = new List<string>();

    void Awake()
    {
        GetTree();
    }

    void GetTree(){
        xml.LoadXml(xmldocument.text);
        XmlNodeList textList = xml.GetElementsByTagName("conversation");

        foreach ( XmlNode conversation in textList) {

            XmlNodeList content = conversation.ChildNodes;

            foreach (XmlNode node in content) {

                switch (node.Name)
                {
                    case "text":
                        conversationText.Add(node.InnerText);
                        break;

                    case "response":
                        responsesText.Add(node.InnerText);
                        break;

                    default:
                        Debug.Log("Name not found");
                        break;
                }
            }
        }
        SendToReciever();
    }

    void SendToReciever() {
        reciever.recieve(conversationText, responsesText);
    }
}
