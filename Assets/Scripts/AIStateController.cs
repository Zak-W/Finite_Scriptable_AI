using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateController : MonoBehaviour
{
    //instances of the enemy and the player for validation
    [SerializeField]
    public GameObject enemyObject;
    [SerializeField]
    public GameObject player;
    //list of materials for the enemy depending on type
    [SerializeField]
    private Material[] aiMaterials;
    //array of states given by player via serializefield
    [SerializeField]
    private State[] aiStates;
    [SerializeField]
    private int currentState;

    //navAgent, Waypoints
    [SerializeField]
    public NavMeshAgent navAgent;
    [SerializeField]
    public List<Transform> wayPointList;
    [SerializeField]
    public int nextWayPoint;

    //delegate for variables
    [SerializeField]
    private AiVariables dataSet;

    //time in each state
    [SerializeField]
    private float timeinState;


    void Awake()
    {
        //gets NavmeshAgent
        navAgent = GetComponent<NavMeshAgent>();
        SetupAI();
    }

    public void SetupAI()
    {
        //setup the default ai state - melee, and then use it to set everything else
        dataSet.ChangeAI(0);
        dataSet.aiDelegate();
        //bool to set up Nav Meshes and other AI requirements
        if (dataSet.isActive == true)
        {
            enemyObject.GetComponent<Renderer>().material = aiMaterials[0];
            GameObject[] objects = GameObject.FindGameObjectsWithTag("WayPoint");
            foreach(GameObject waypointObject in objects)
            {
                wayPointList.Add(waypointObject.transform);
            }
            navAgent.speed = dataSet.speed;
            navAgent.stoppingDistance = dataSet.range;
            navAgent.enabled = true;
        }
        else
        {
            navAgent.enabled = false;
        }
    }

    void Update()
    {
        //each frame run State, if Ai isnt active then dont run
        if (!dataSet.isActive)
        {
            return;
        }
        //increase time in state, move through states, Then check to see if state changed
        timeinState += Time.deltaTime;
        aiStates[currentState].UpdateState(this);
        ChangeState();
    }

    public void ChangeState()
    {
        //change to next State for the AI based on certain states
        switch (currentState)
        {
            case 0:
                if(Vector3.Distance(player.transform.position, gameObject.transform.position) <= navAgent.stoppingDistance)
                {
                    Debug.Log("ALERT");
                    currentState = 1;
                    timeinState = 0;
                }
                break;
            case 1:
                if(timeinState >= 8.0f)
                {
                    currentState = 0;
                    timeinState = 0;
                }
                break;
            default:
                break;
        }
    }

    public void AiSwitch()
    {
        //button changes state from ranged to melee
        if(dataSet.type == 0)
        {
            dataSet.ChangeAI(1);
            dataSet.aiDelegate();
            navAgent.speed = dataSet.speed;
            navAgent.stoppingDistance = dataSet.range;
            enemyObject.GetComponent<Renderer>().material = aiMaterials[1];
        }
        else
        {
            dataSet.ChangeAI(0);
            dataSet.aiDelegate();
            navAgent.speed = dataSet.speed;
            navAgent.stoppingDistance = dataSet.range;
            enemyObject.GetComponent<Renderer>().material = aiMaterials[0];
        }
    }
}