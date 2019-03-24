using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AIObjects/Actions/Chase")]
public class ChaseAction : Action
{
    //override Act
    public override void Act(AIStateController controller)
    {
        Chase(controller);
    }

    private void Chase(AIStateController controller)
    {
       //self explanatory, moves toward player
        controller.navAgent.destination = controller.player.transform.position;
        controller.navAgent.isStopped = false;
    }
}
