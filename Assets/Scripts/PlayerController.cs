using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    //navmeshagent setup
    [SerializeField]
    private NavMeshAgent navAgent;

    private Ray shootRay;

    // Use this for initialization
    void Start ()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //basic point to move script
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                navAgent.destination = hit.point;
            }
        }

        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            navAgent.isStopped = true;
        }
        else
        {
            navAgent.isStopped = false;
        }
    }
}
