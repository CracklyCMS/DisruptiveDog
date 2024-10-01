using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
}
