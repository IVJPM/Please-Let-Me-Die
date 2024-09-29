using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingState : CharacterState
{
    [SerializeField] PlayerInteractable playerInteractable;
    [SerializeField] PlayerManager playerManager;

    public override void EnterState()
    {
        playerInteractable.InteractionAnimation();
    }

    public override void ExitState()
    {

    }

    public override void RunState(GameObject characterInteraction)
    {
        if (this.enabled == true)
        {
            characterInteraction.TryGetComponent(out PlayerInteractable interaction);
            //Debug.Log(interaction.gameObject.name);
        }
    }
}
