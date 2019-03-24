using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiVariables : MonoBehaviour
{
    //create the Delegate and its requirements
    public delegate void AiDelegate();
    public AiDelegate aiDelegate;

    //variables for enemy requirements
    [SerializeField]
    public float speed;
    [SerializeField]
    public float range;
    [SerializeField]
    public bool isActive = false;
    [SerializeField]
    public int type;

    void AddMelee()
    {
        //change type, speed and stopping distance
        type = 0;
        range = 2.75f;
        speed = 4f;
    }

    void AddRanged()
    {
        //change type, speed and stopping distance
        type = 1;
        range = 5f;
        speed = 2f;
    }

    public void ChangeAI(int type)
    {
        //reset Delegate to prevent errors
        if (aiDelegate != null)
        {
            aiDelegate = null;
        }
        //switch case to change state, gives delegate different functions
        switch(type)
        {
            case 0:
                aiDelegate += AddMelee;
                break;
            case 1:
                aiDelegate += AddRanged;
                break;
            default:
                aiDelegate += AddMelee;
                break;
        }
        //activate enemy
        isActive = true;
    }
}
