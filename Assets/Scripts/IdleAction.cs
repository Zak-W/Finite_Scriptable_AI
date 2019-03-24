using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIObjects/Actions/Idle")]
public class IdleAction : Action
{
    private float timeTaken;

    //override Act
    public override void Act(AIStateController controller)
    {
        Idle(controller);
    }

    private void Idle(AIStateController controller)
    {
        //if the navAgent is not moving, rotate
        if (controller.navAgent.isStopped)
        {
            timeTaken += Time.deltaTime;
            //rotate every frame until 1.5 seconds
            if (timeTaken <= 1.5)
            {
                controller.transform.Rotate(Vector3.up * timeTaken);
            }
            else
            {
                timeTaken = 0;
            }
        }
        else
        {
            return;
        }
    }
}
