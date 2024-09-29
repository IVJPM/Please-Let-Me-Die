using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatePractice : MonoBehaviour
{
    /*[SerializeField] CharacterState movingState;
    [SerializeField] CharacterState idleState;
    [SerializeField] CharacterState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;
        currentState.RunState();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(currentState == idleState)
            {
                ChangeState(movingState);
            }
            else if(currentState == movingState)
            {
                ChangeState(idleState);
            }
        }
        Debug.Log(currentState);
    }

    private void ChangeState(CharacterState desiredState)
    {
        if (desiredState == currentState)
        {
            return;
        }
        else if (desiredState != currentState)
        {
           // currentState.ExitState();
            currentState = desiredState;
            currentState.RunState();
        }
    }*/
}
