using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Transform cameraPivotTransform;

    [SerializeField] PlayerManager player;
    //[SerializeField] Transform camerBattlePosition;
    [SerializeField] float cameraDistance;

    public float rotationSpeed = .05f;
    //float mouseSensitivity = 3f;

    public Vector3 newPos;
    public Vector3 currentPos;
    Vector3 smoothingVelocity = Vector3.zero;

    public GameObject cam;

    //Split between other game scripts to test which works better
    [Header("Camera Settings")]
    public float cameraSmoothSpeed = .25f;
    public float upDownRotationSpeed = 40;
    public float leftRightRotationSpeed = 40;
    //[SerializeField] float minPivot = -20; // Lowest point to look down
    //[SerializeField] float maxPivot = 40; // Highest point to look up
    //[SerializeField] float cameraCollisionOffset = .2f;
    [SerializeField] LayerMask collideWithLayers;

    [Header("Camera Values")]
    private Vector3 cameraVelocity;
    private Vector3 cameraObjectPosition;
    [SerializeField] float leftRightLookAngle;
    [SerializeField] float upDownLookAngle;
    public float cameraHorizontalInput;
    public float cameraVerticalInput;
    private float defaultCameraPosition;
    private float targetCameraPosition;

    private Vector3 cameraPosition;
    Vector3 velocity;
    private void Start()
    {
        defaultCameraPosition = cam.transform.localPosition.z;
    }

    void LateUpdate()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        cameraPosition = transform.position;

        cameraVerticalInput += Input.GetAxis("Mouse X") * upDownRotationSpeed * Time.deltaTime;
        cameraHorizontalInput += Input.GetAxis("Mouse Y") * leftRightRotationSpeed* Time.deltaTime;

        cameraHorizontalInput = Mathf.Clamp(cameraHorizontalInput, 3, 30);

        newPos = new Vector3(cameraHorizontalInput, cameraVerticalInput);
        //currentPos = Vector3.Slerp(currentPos, newPos, .15f);
        currentPos = Vector3.SmoothDamp(currentPos, newPos, ref smoothingVelocity, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(currentPos);

        transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 1f, player.gameObject.transform.position.z) - transform.forward * cameraDistance;// placed at bottom to avoid shaky camera
    }

    /*public void CameraBattleScene()
    {
        transform.position = Vector3.Lerp(transform.position, camerBattlePosition.position, Time.deltaTime * 2.5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, camerBattlePosition.rotation, Time.deltaTime * 3.5f);
    }
    //Split between other game scripts
    private void FollowTarget()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.gameObject.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
        transform.position = targetCameraPosition;
    }

    private void HandleCameraRotations()
    {
        cameraHorizontalInput = Input.GetAxis("Mouse X");
        cameraVerticalInput = Input.GetAxis("Mouse Y");

        leftRightLookAngle += (cameraHorizontalInput * leftRightRotationSpeed) * Time.deltaTime;
        upDownLookAngle += (cameraVerticalInput * upDownRotationSpeed) * Time.deltaTime;

        upDownLookAngle = Mathf.Clamp(upDownLookAngle, minPivot, maxPivot);

        Vector3 cameraRotation = Vector3.zero;
        cameraRotation.y = leftRightLookAngle;
        Quaternion targetRotation = Quaternion.Euler(cameraRotation);
        transform.rotation = targetRotation;

        cameraRotation = Vector3.zero;
        cameraRotation.x = upDownLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        cameraPivotTransform.localRotation = targetRotation;

        //cam.transform.position = player.gameObject.transform.position - transform.forward * cameraDistance;// placed at bottom to avoid shaky camera
    }

    private void HandleCameraCollisions()
    {
        targetCameraPosition = defaultCameraPosition + 1.5f;
        RaycastHit hit;
        Vector3 direction = cam.transform.position - cameraPivotTransform.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivotTransform.position, cameraCollisionOffset, direction, out hit, Mathf.Abs(targetCameraPosition), collideWithLayers))
        {
            float distanceFromHitObject = Vector3.Distance(cameraPivotTransform.position, hit.point);
            targetCameraPosition = -(distanceFromHitObject - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetCameraPosition) < cameraCollisionOffset)
        {
            targetCameraPosition = -cameraCollisionOffset;
        }

        cameraObjectPosition.z = Mathf.Lerp(cam.transform.localPosition.z, targetCameraPosition, .2f);
        cam.transform.localPosition = cameraObjectPosition;
    }*/
}
