using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private NavMeshAgent navigator;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navigator = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        print(navigator.velocity);
        if(Mathf.Abs(navigator.velocity.x) >= 1f || Mathf.Abs(navigator.velocity.z) >= 1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void Movement()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            navigator.destination = hit.point;
            Quaternion lookRotation = Quaternion.LookRotation(hit.point - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1);

        }
    }
}
