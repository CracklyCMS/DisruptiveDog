using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour
{
    public TextMeshProUGUI lockText;
    public AudioClip lockSound;

    private bool inProximity = false;
    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        StopAllCoroutines();
        if (inProximity) {
            Debug.Log("Clicked");
            StartCoroutine(ShowText());
            audioPlayer.clip = lockSound;
            audioPlayer.Play();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("HIT");
            inProximity = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Left");
        inProximity = false;
    }

    IEnumerator ShowText()
    {
        lockText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        lockText.gameObject.SetActive(false);
    }

}
