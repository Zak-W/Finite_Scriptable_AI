using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AIObjects/Actions/Attack")]
public class AttackAction : Action
{
    private float timeTaken;

    //override act
    public override void Act(AIStateController controller)
    {
        Attack(controller);
    }

    private void Attack(AIStateController controller)
    {
        //if in range, and if attack time is passed, do attack
        timeTaken += Time.deltaTime;
        if(controller.navAgent.remainingDistance <= controller.navAgent.stoppingDistance)
        {
            if (timeTaken >= 2f)
            {
                Debug.Log("Attack Engaged");
                timeTaken = 0;
            }
        }
        else
        {
            return;
        }
    }
}
