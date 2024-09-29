using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    //Work on developing event inputs with the old input system, switch back to new input system if it doesn't work

    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }
    public Vector3 moveInput { get; private set; }

    public float upDownCameraMovement { get; private set; }
    public float leftRightCameraMovement { get; private set; }
    public Vector2 cameraInput { get; private set; }

    public bool jump {  get; private set; }

    public bool select { get; private set; }

    void Start()
    {

    }

    void Update()
    {
        PlayerMovementInputs();
        Jump();
        SelectButton();
    }

    private void PlayerMovementInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(horizontalInput, 0, verticalInput);
    }

    private void Jump()
    {
        jump = Input.GetButtonDown("Jump");
        if (jump) 
        Debug.Log("Jumping");
    }

    private void SelectButton()
    {
        select = Input.GetButtonDown("Select");
        if (select)
        Debug.Log("Selecting");
    }
}
