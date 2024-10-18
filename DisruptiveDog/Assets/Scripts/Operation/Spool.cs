using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Spool : MonoBehaviour
{
    public GameObject handle;
    public Tapeworm worm;
    public OperationManager operationManager;

    private float mouseDistance;
    private Vector3 lastPosition;
    private float threshold = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TrackMouse();
        }
    }

    private void TrackMouse()
    {
        var newPosition = Input.mousePosition;
        mouseDistance += Mathf.Abs(newPosition.y - lastPosition.y);
        print(mouseDistance);
        lastPosition = newPosition;
        handle.transform.eulerAngles = new Vector3(mouseDistance/2, -31.32f, 0);
        if(mouseDistance > threshold)
        {
            print(threshold);
            if (threshold >= 9000)
            {
                StartCoroutine(EndReel());
                worm.RemoveFirstPoint();
                threshold += 1000;
            }
            else
            {
                worm.AddNextPointFromTransforms();
                threshold += 1000;
            }
        }
        
    }

    IEnumerator EndReel()
    {
        yield return new WaitForSeconds(1);
        operationManager.BeginStitching();
    }
}
