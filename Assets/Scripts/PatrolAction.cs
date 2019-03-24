using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIObjects/Actions/Patrol")]
public class PatrolAction : Action
{
    private float timeTaken;

    //override act
    public override void Act(AIStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(AIStateController controller)
    {
        timeTaken += Time.deltaTime;
        //move every few seconds to next waypoint
        if (timeTaken >= 3)
        {
            controller.navAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            controller.navAgent.isStopped = false;

            //change wapoint to next
            if (controller.navAgent.remainingDistance <= controller.navAgent.stoppingDistance && !controller.navAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
                timeTaken = 0;
            }
        }
        else
        {
            controller.navAgent.isStopped = true;
            return;
        }
    }
}