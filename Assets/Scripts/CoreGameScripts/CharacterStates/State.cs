using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State: MonoBehaviour
{
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void RunState()
    {
        Debug.Log("Move State");
    }
}
