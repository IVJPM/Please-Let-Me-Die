using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInputManager playerInputManager;
    PlayerMovement playerMovement;
    PlayerInteractable playerInteractable;

    [SerializeField] float playerMovementSpeed;
    //[SerializeField] float enemyView;
    Vector3 enemyViewDirection;
    Vector3 enemyPositionToPlayer;

    //public static event EventHandler OnPlayerFreeState;
    //public static event EventHandler OnPlayerBattleState;

    [SerializeField] CharacterState runningState;
    [SerializeField] CharacterState walkingState;
    [SerializeField] CharacterState idleState;
    [SerializeField] CharacterState interacitonState;
    [SerializeField] CharacterState currentCharacterState;

    void Start()
    {
        playerInputManager = GetComponentInChildren<PlayerInputManager>();
        playerMovement = GetComponentInChildren<PlayerMovement>();
        playerInteractable = GetComponent<PlayerInteractable>();

        currentCharacterState = idleState;
        currentCharacterState.RunState(this.gameObject);
    }
    private void Update()
    {
        bool isMoving;
        if (playerInputManager.moveInput != Vector3.zero && playerInteractable.isInteracting == false)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving && Mathf.Abs(playerInputManager.horizontalInput) >= .5f || isMoving && Mathf.Abs(playerInputManager.verticalInput) >= .5f)
        {
            ChangeState(runningState);
        }
        else if(isMoving && Mathf.Abs(playerInputManager.horizontalInput) < .5f || isMoving && Mathf.Abs(playerInputManager.verticalInput) < .5f)
        {
            ChangeState(walkingState);
        }
        else if(playerInteractable.isInteracting == true)
        {
            ChangeState(interacitonState);
        }
        else if(!isMoving)
        {
            ChangeState(idleState);
        }
        currentCharacterState.RunState(this.gameObject);
    }

    private void ChangeState(CharacterState desiredState)
    {
        if(currentCharacterState == desiredState)
        {
            return;
        }    
        if (currentCharacterState != desiredState)
        {
            currentCharacterState.ExitState();
            currentCharacterState = desiredState;
            currentCharacterState?.EnterState();
        }
    }
}
