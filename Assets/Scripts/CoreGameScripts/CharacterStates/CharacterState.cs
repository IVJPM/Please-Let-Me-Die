using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour, IStateMachine
{
    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void RunState(GameObject character)
    {
        //Debug.Log("Just chilling :)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
