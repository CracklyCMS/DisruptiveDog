using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeartEffect : MonoBehaviour
{

    public Image heart;

    private bool isActive;
    private float yPosition = -250;
    private float alpha = .9f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateHeart());
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive && heart.transform.localPosition.y <= -100)
        {
            heart.transform.localPosition = new Vector3(140, yPosition, 0);
            heart.color = new Color(1, 0, 0, alpha);
            yPosition += 1;
            alpha -= .005f;
        }
        else
        {
            yPosition = -250;
            alpha = .9f;
            isActive = false;
            heart.gameObject.SetActive(false);
        }
    }

    IEnumerator AnimateHeart()
    {
        heart.gameObject.SetActive(true);
        heart.transform.localPosition = new Vector3(145, -250, 0);
        isActive = true;
        yield return new WaitForSeconds(Random.Range(5, 8));
        StartCoroutine(AnimateHeart());
    }
}
