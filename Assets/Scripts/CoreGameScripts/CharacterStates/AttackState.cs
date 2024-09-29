using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharacterState
{
    [SerializeField] AnimationClip attackAnimation;
    [SerializeField] Animator playerAnimation;
    public override void EnterState()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimation, attackAnimation, .1f);
    }

    public override void ExitState()
    {

    }

    public override void RunState(GameObject characterAttack)
    {
        
    }
}
