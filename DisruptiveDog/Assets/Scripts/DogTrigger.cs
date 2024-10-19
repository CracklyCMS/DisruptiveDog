using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogTrigger : MonoBehaviour
{
    public GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.actNum != 2)
        {
            GameManager.actNum = 2;
            SceneManager.LoadScene("Operation");
        }
    }
}
