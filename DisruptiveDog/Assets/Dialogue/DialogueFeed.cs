using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class DialogueFeed : MonoBehaviour
{
    public static DialogueFeed Get()
    {
        DialogueFeed feed = GameObject.FindAnyObjectByType<DialogueFeed>() as DialogueFeed;
        Debug.Assert(feed != null, "No DialogueFeed in Scene");
        return feed;
    }

    [Header("Settings")]
    public float CharactersPerSecond = 5;
    public bool ReplaceEmptyMessages = false;
    public string EmptyStringReplacementText = "...";

    [Header("References")]
    public Image DialoguePanel;
    public TextMeshProUGUI CharNameText;
    public TextMeshProUGUI MessageText;
    public InputActionAsset InputActions;
    public string[] ActionsToTurnOffInDialogue;

    [Header("Data")]
    public DialogueMessageBundle DialogueBundle;

    int m_messageIndex;
    string m_currCharName;
    string m_currMessage;

    void Awake()
    {
        CloseDialogue();
    }

    void Start()
    {
        
    }

    public void StartDialogue(DialogueMessageBundle bundle)
    {
        Debug.Assert(bundle != null, "Null message bundle");
        Debug.Assert(bundle.MessageCount >= 1, "Empty message bundle");

        DialogueBundle = bundle;
        m_messageIndex = 0;

        SetMessage(DialogueBundle.GetMessage(m_messageIndex));

        DialoguePanel.gameObject.SetActive(true);
        if (bundle.BlackOutScreen)
            DialoguePanel.color = new Color(0, 0, 0, 1);
        else
            DialoguePanel.color = new Color(0, 0, 0, 0);
    }

    public void CloseDialogue()
    {
        DialoguePanel.gameObject.SetActive(false);
    }

    public void NextMessage()
    {
        m_messageIndex++;

        // Close if no more messages
        if (m_messageIndex >= DialogueBundle.MessageCount)
        {
            CloseDialogue();
            return;
        }

        SetMessage(DialogueBundle.GetMessage(m_messageIndex));
    }

    void SetMessage(DialogueMessage message)
    {
        m_currCharName = message.CharacterName;
        m_currMessage = ReplaceStringIfEmpty(message.MessageText);
    }

    void Update()
    {
        CharNameText.text = m_currCharName;
        MessageText.text = m_currMessage;
    }

    string ReplaceStringIfEmpty(string text)
    {

        if (ReplaceEmptyMessages && text == null || text.Length == 0)
            return EmptyStringReplacementText;
        
        return text;
    }
}
