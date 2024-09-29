using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    [SerializeField] AnimationClip playerIdleAnimation;
    [SerializeField] Animator playerAnimator;

    public override void EnterState()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimator, playerIdleAnimation, .1f);
    }

    public override void ExitState()
    {
        
    }

    public override void RunState(GameObject character)
    {
        
    }
}
