using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncisionMarker : MonoBehaviour, IPointerDownHandler
{
    private SpriteRenderer sprite;
    public Sprite circleSprite;
    public IncisionMarker nextMarker;
    public SpriteRenderer nextLine;
    public bool isNext;
    public bool isLastMarker;
    public OperationManager opManager;

    private void Start()
    {
        AddPhysics2DRaycaster();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(opManager.xrayOnOff != true)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            if(sprite.sprite != circleSprite)
            {
                gameObject.transform.localScale = new Vector3(.05f, .05f, 1f);
                sprite.sprite = circleSprite;
                opManager.changedMarkers++;
                if(opManager.changedMarkers == 4)
                {
                    opManager.SetFirstMarker();
                }
            }
            else if (isNext)
            {
                isNext = false;
                nextLine.enabled = true;
                nextMarker.isNext = true;
                if (isLastMarker)
                {
                    opManager.OpenDog();
                }
            }
        }
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}
