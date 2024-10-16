using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntestineMarker : MonoBehaviour, IPointerDownHandler
{
    private SpriteRenderer sprite;
    public Sprite squareSprite;
    
    public OperationManager opManager;

    private void Start()
    {
        AddPhysics2DRaycaster();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            if (sprite.sprite != squareSprite)
            {
                gameObject.transform.localScale = new Vector3(.05f, .15f, 1f);
                gameObject.transform.rotation = new Quaternion(0, 0, -0.0936738551f, 0.995602965f);
                sprite.sprite = squareSprite;
                opManager.GetSpindle();
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
