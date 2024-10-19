using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartDialogue : MonoBehaviour
{
    public DialogueMessageBundle messageBundle;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(messageBundle != null, "");
        DialogueFeed feed = DialogueFeed.Get();
        feed.StartDialogue(messageBundle);
    }
}
