using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IHandleMovement
{
    PlayerInputManager playerInputManager;
    [SerializeField] GameObject cameraContainer;

    [Header("Player Movement Inputs")]
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    public Vector3 moveInput;
    [SerializeField] float leftRightRotation;
    [SerializeField] float upDownRotation;
    [SerializeField] Vector2 playerLookRotation;
    public Quaternion playerRotationAngles { get; private set; }
    [SerializeField] float gravityModifier;

    private Rigidbody playerRb;
    private Animator playerAnimator;
    private bool speedIsBoosted;
    public float powerUpTimer;

    float smoothMove;
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }


    private void FixedUpdate()
    {
        RetrievePlayerMovementInputs();
    }

    private void RetrievePlayerMovementInputs()
    {
        horizontalInput = playerInputManager.horizontalInput;
        verticalInput = playerInputManager.verticalInput;
        moveInput = playerInputManager.moveInput;
    }

    public void HandlePlayerMovement(float movementSpeed)
    {
        moveInput = new Vector3(horizontalInput, 0, verticalInput);
        moveInput.Normalize();
        moveInput.y = 0;

        float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + cameraContainer.transform.eulerAngles.y;

        if (moveInput != Vector3.zero)
        {
            //float rotateAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothMove, 2f * Time.deltaTime);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            
            Quaternion rotate = Quaternion.Euler(0, targetAngle, 0);

            //playerRb.rotation = Quaternion.Slerp(playerRb.rotation, rotate, .1f);
            playerRb.velocity = moveDirection * movementSpeed;

            //playerRb.MoveRotation(rotate);
            playerRb.MoveRotation(Quaternion.Slerp(playerRb.rotation, rotate, 15f * Time.deltaTime));

            /*playerRb.velocity = moveInput * movementSpeed;
            
            Quaternion playerDirection = Quaternion.LookRotation(playerRb.velocity, Vector3.up);
            
            Quaternion lookRotation = playerRb.rotation;
            Quaternion rbRotation = Quaternion.Slerp(playerRb.rotation, playerDirection, .3f);
            playerRb.MoveRotation(rbRotation);

            /*Vector3 camForward = cameraContainer.transform.forward;
            camForward.y = 0;
            Quaternion camRelativeRotation = Quaternion.FromToRotation(Vector3.forward, camForward * Time.deltaTime);
            Vector3 lookToward = camRelativeRotation * moveInput;
            Quaternion camPlayerRotation = Quaternion.LookRotation(lookToward, Vector3.up);
            playerRb.velocity = lookToward * movementSpeed;*

            Quaternion finalRotation = Quaternion.RotateTowards(playerRb.rotation, camPlayerRotation, 750 * Time.fixedDeltaTime);
            Quaternion smoothRotation = Quaternion.Slerp(camPlayerRotation, finalRotation, 100 * Time.deltaTime);
            //playerRb.MoveRotation(smoothRotation);
            playerRb.rotation = smoothRotation;*/
        }
    }

    public void Rotation()
    {
        //For if separating movement and rotation is needed
        Vector3 playerRotation;

        playerRotation = Vector3.zero;
        playerRotation = cameraContainer.transform.forward * playerRb.velocity.z;
        playerRotation += cameraContainer.transform.right * playerRb.velocity.x;
        playerRotation.Normalize();
        playerRotation.y = 0;

        if (playerRotation == Vector3.zero)
        {
            playerRotation = transform.forward;
        }

        Quaternion rotationDirection = Quaternion.LookRotation(playerRotation);
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, rotationDirection, .35f);
        transform.rotation = newRotation;
    }
}
