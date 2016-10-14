using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ConvertToDialog : MonoBehaviour {

    [SerializeField]
    GameObject textObject;
    Text dialogText;

    [SerializeField]
    GameObject nextbutton;

    [SerializeField]
    GameObject responseholderGameobject;
    Transform responseholder;

    [SerializeField]
    GameObject buttonPrefab;

    List<string> conversationText = new List<string>();
    List<string> responsesText = new List<string>();

    int currentTextRange = 0;

    void Start() {
        dialogText = textObject.GetComponent<Text>();
        responseholder = responseholderGameobject.GetComponent<Transform>();
        nextText();
    }
    
    public void recieve(List<string> ConversationText, List<string> ResponsesText) {
        conversationText = ConversationText;
        responsesText = ResponsesText;
    }

    public void nextText() {
        if (currentTextRange < conversationText.Count)
        {
            dialogText.text = conversationText[currentTextRange];
            currentTextRange++;
        }
        else {
            ToResponses();
        }
    }

    void ToResponses() {

        nextbutton.SetActive(false);
        for (int i = 0; i < responsesText.Count; i++) {
            GameObject button = Instantiate(buttonPrefab, new Vector3(responseholder.position.x / responsesText.Count * (i + responsesText.Count ) , responseholder.position.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            button.transform.parent = responseholder;

            button.GetComponentInChildren<Text>().text = responsesText[i];
        }
    }
}
