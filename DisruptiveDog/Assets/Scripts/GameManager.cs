using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player;
    public Camera cam1;
    public Camera cam2;
    public GameObject nurse1;
    public GameObject nurse2;
    public GameObject dogTrigger;

    public int actNum = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        cam1 = GameObject.Find("Cam2").GetComponent<Camera>();
        cam2 = GameObject.Find("Cam3").GetComponent<Camera>();
        nurse1 = GameObject.FindGameObjectWithTag("Nurse1");
        nurse2 = GameObject.FindGameObjectWithTag("Nurse2");
        nurse2.SetActive(false);
        if (actNum == 2)
        {
            print("ACT 2");
            
            nurse1.SetActive(false);
            nurse2.SetActive(true);
            dogTrigger = GameObject.Find("DogTrigger");
            Destroy(dogTrigger);
            NavMeshAgent nav = player.gameObject.GetComponent<NavMeshAgent>();
            nav.enabled = false;
            player.gameObject.transform.position = new Vector3(15.8369999f, 1.58333337f, -7.37100029f);
            nav.enabled = true;
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
        else
        {
            actNum = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
