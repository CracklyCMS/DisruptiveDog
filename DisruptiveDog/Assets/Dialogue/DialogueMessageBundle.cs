using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;


[System.Serializable]
public struct DialogueMessage
{
    public string CharacterName;
    public string MessageText;
}

[CreateAssetMenu(fileName = "New Dialogue Bundle", menuName = "Create New Dialogue", order = 0)]
public class DialogueMessageBundle : ScriptableObject
{
    [SerializeField]
    public DialogueMessage[] Messages;

    public int MessageCount
    {
        get { return Messages.Length; }
    }

    public DialogueMessage GetMessage(int index)
    {
        Debug.Assert(index >= 0);
        Debug.Assert(index < Messages.Length);

        return Messages[index];
    }
}
