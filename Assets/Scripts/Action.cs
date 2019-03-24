using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    //abstract function to override for each action
    public abstract void Act(AIStateController controller);
}