using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AIObjects/State")]
public class State : ScriptableObject
{
    //given actions by user
    [SerializeField]
    private Action[] actions;

    public void UpdateState(AIStateController controller)
    {
        DoActions(controller);
    }

    private void DoActions(AIStateController controller)
    {
        //do each act for each action
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }


}