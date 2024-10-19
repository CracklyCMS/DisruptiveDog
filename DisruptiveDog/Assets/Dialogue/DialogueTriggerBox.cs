using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBox : MonoBehaviour
{
    public DialogueMessageBundle BundleToTrigger;
    public DialogueTriggerBox[] PrerequisiteTriggers;

    public bool AlreadyTriggered
    {
        get { return m_burned; }
    }

    private bool m_burned;

    // Start is called before the first frame update
    void Start()
    {
        m_burned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_burned)
            return;

        foreach (DialogueTriggerBox trigger in PrerequisiteTriggers)
        {
            if (!trigger.AlreadyTriggered)
            {
                Debug.Log("Prereq triggers not met");
                return;
            }
        }

        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Player Overlapt with " + gameObject.name);

        DialogueFeed.Get().StartDialogue(BundleToTrigger);
        m_burned = true;
    }
}
