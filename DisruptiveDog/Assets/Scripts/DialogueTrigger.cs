using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogue;
    public Image textBox;
    public TextMeshProUGUI text;

    private bool doOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (doOnce)
        {
            StartCoroutine(DisplayTextBox());
            doOnce = false;
        }
    }

    IEnumerator DisplayTextBox()
    {
        textBox.gameObject.SetActive(true);
        text.text = dialogue;
        yield return new WaitForSeconds(3);
        textBox.gameObject.SetActive(false);
    }
}
