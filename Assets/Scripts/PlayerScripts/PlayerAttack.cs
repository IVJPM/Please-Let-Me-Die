using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform target;

    Rigidbody playerRb;
    Vector3 playerPosition;
    Vector3 playerAttackDirection;

    [SerializeField] float playerAttackDistance;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerAttackDistance = Vector3.Distance(playerPosition, target.position);
        Debug.Log(playerAttackDistance);
    }

    public void AttackEnemy()
    {
        playerPosition = transform.position;
        playerPosition.y = 0;
        playerAttackDirection = playerPosition - target.position;
        
        if( playerAttackDistance >= 1f)
        {
            //transform.position -= new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + .1f);
            //playerRb.AddForce(playerAttackDirection, ForceMode.Force);
            playerRb.velocity += -playerAttackDirection * 5f;
        }

    }
}
