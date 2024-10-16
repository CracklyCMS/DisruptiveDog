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

    private float zoomscaleX = 1;
    private float zoomscaleY = 1;
    private float zoomposX = 0;
    private float zoomposY = 1;
    
    public void EnableDisableXRAY()
    {
        xrayOnOff = !xrayOnOff;
        xrayMachine.SetActive(xrayOnOff);
    }

    private void Update()
    {
        if (zoomOnOff)
        {
            if (zoomscaleX <= 2)
            {
                dog.gameObject.transform.localScale = new Vector3(zoomscaleX, zoomscaleY, 1);
                zoomscaleX += .01f;
                zoomscaleY += .01f;
            }
            if (zoomposY <= 4)
            {
                dog.gameObject.transform.position = new Vector3(zoomposX, zoomposY, -.1f);
                zoomposY += .05f;
                if (zoomposX >= -.25f)
                {
                    zoomposX -= .01f;
                }
            }
            
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

    public void GetSpindle()
    {

    }
}
