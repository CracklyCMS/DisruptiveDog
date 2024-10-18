using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stitch : MonoBehaviour, IPointerDownHandler
{
    private SpriteRenderer sprite;
    public Sprite stitchSprite;
    public Stitch nextMarker;
    public bool isNext;
    public bool isMiddleMarker;
    public bool isLastMarker;
    public OperationManager opManager;

    private void Start()
    {
        AddPhysics2DRaycaster();
        sprite = GetComponent<SpriteRenderer>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            if (sprite.sprite != stitchSprite && isNext)
            {
                gameObject.transform.localScale = new Vector3(.075f, .025f, 1f);
                gameObject.transform.rotation = new Quaternion(0, 0, -0.100188084f, 0.994968534f);
                sprite.sprite = stitchSprite;
                isNext = false;
                nextMarker.gameObject.SetActive(true);
                nextMarker.isNext = true;
                opManager.Stitch();
                if (isLastMarker)
                {
                    opManager.Stitch();
                    opManager.EndSequence();
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
