using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : CharacterState
{
    [SerializeField] float movementSpeed;
    [SerializeField] AnimationClip runningAnimation;
    [SerializeField] Animator playerAnimation;

    public override void EnterState()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimation, runningAnimation, .2f);
    }

    public override void ExitState()
    {

    }

    public override void RunState(GameObject characterMovement)
    {
        if (this.enabled == true)
        {
            characterMovement.TryGetComponent(out IHandleMovement character);
            character.HandlePlayerMovement(movementSpeed);
            //character.Rotation();
        }
    }
}
