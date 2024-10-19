using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationManager : MonoBehaviour
{
    public SpriteRenderer dog;
    public Sprite openDog;
    public Sprite[] stitchSprites;
    public TextMeshProUGUI taskText;
    public GameObject xrayMachine;
    public int changedMarkers = 0;
    public IncisionMarker[] allMarkers;
    public GameObject[] allLines;
    public IncisionMarker firstMarker;
    public IntestineMarker intestineMarker;
    public Tapeworm worm;
    public GameObject spindle;
    public Stitch[] allStitches;
    private int stitchIndex;

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
            if(zoomposY <= 4)
            {
                dog.gameObject.transform.position = new Vector3(zoomposX, zoomposY, -.1f);
                zoomposY += .05f;
                if (zoomposX >= -.25f)
                {
                    zoomposX -= .01f;
                }
            }
            else
            {
                intestineMarker.gameObject.SetActive(true);
            }
        }
        else if (!zoomOnOff && taskText.text == "Stitch Belly") {
            {
                intestineMarker.gameObject.SetActive(false);
                if (zoomscaleX >= 1)
                {
                    dog.gameObject.transform.localScale = new Vector3(zoomscaleX, zoomscaleY, 1);
                    zoomscaleX -= .01f;
                    zoomscaleY -= .01f;
                }
                if (zoomposY >= 1)
                {
                    dog.gameObject.transform.position = new Vector3(zoomposX, zoomposY, -.1f);
                    zoomposY -= .05f;
                    if (zoomposX <= 0)
                    {
                        zoomposX += .01f;
                    }
                }
                else
                {
                    foreach (Stitch stitch in allStitches)
                    {
                        stitch.gameObject.SetActive(true);
                    }
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
        worm.gameObject.SetActive(true);
        spindle.SetActive(true);
        taskText.text = "Fish Out Worm";
    }

    public void BeginStitching() 
    {
        zoomOnOff = false;
        Destroy(worm.gameObject);
        Destroy(spindle.gameObject);
        intestineMarker.gameObject.transform.localScale = new Vector3(.01f, .15f, 1f);
        taskText.text = "Stitch Belly";

    }

    public void EndSequence()
    {
        taskText.text = "Operation Complete";
        StartCoroutine(LoadNextScene());
    }

    public void Stitch()
    {
        dog.sprite = stitchSprites[stitchIndex];
        if(stitchIndex != 2)
        {
            stitchIndex++;
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Clinic");
    }
}
