using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OperationManager : MonoBehaviour
{
    public SpriteRenderer dog;
    public Sprite openDog;
    public TextMeshProUGUI taskText;
    public GameObject xrayMachine;
    public int changedMarkers = 0;
    public IncisionMarker[] allMarkers;
    public GameObject[] allLines;
    public IncisionMarker firstMarker;

    private bool zoomOnOff = false;
    private bool canUseXray = true;
    public bool xrayOnOff = false;
    
    public void EnableDisableXRAY()
    {
        xrayOnOff = !xrayOnOff;
        xrayMachine.SetActive(xrayOnOff);
    }

    private void Update()
    {
        if (zoomOnOff)
        {
            dog.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime * 10);
        }
    }

    public void SetFirstMarker()
    {
        firstMarker.isNext = true;
        taskText.text = "Make Incision";
    }

    public void OpenDog()
    {
        canUseXray = false;
        dog.sprite = openDog;
        taskText.text = "Cut Intestine";
        foreach (IncisionMarker marker in allMarkers)
        {
            Destroy(marker.gameObject);
        }
        foreach (GameObject line in allLines){
            Destroy(line);
        }
        zoomOnOff = true;
    }
}
