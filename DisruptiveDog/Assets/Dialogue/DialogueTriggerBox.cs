using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerBox : MonoBehaviour
{
    public DialogueMessageBundle BundleToTrigger;
    public DialogueTriggerBox[] PrerequisiteTriggers;
    public int MinimumAct = 0;

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

        GameManager GameManager = GameObject.FindFirstObjectByType<GameManager>();
        if (GameManager.actNum < MinimumAct)
        {
            Debug.Log("Minimum act not met");
            return;
        }

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
