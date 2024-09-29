using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    
    [SerializeField] float sphereRadius;
    [SerializeField] Animator playerInteractionAnimation;
    private GameObject weaponItem;
    PlayerInputManager playerInputManager;
    [SerializeField] bool canInteract;
    public bool isInteracting {  get; private set; }

    IInteractable interactable;


    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    void Start()
    {

    }

    void Update()
    {
        interactable = GetInteractableObjects();
        if (interactable == null)
        {
            canInteract = false;
            return;
        }
        else
        {
            canInteract = true;
        }
        if (interactable.IsInteracting() == false)
        {
            isInteracting = false;
        }

        PlayerInteract();
        FaceInteractable();

        //InteractWithWeapon();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), sphereRadius);

    }

    /*private GameObject InteractWithWeapon()
    {
        foreach (GameObject weapon in WeaponsManager.instance.Weapon)
        {
            weaponItem = weapon;
           
            if (gameObject.GetComponent<PlayerInputManager>().interact == true)
            {
                if (Vector3.Distance(weaponItem.transform.position, transform.position) < 1.5f)
                {
                    if (weaponItem.CompareTag("Sword") && weaponItem.activeSelf == true)
                    {
                        print("Pick up sword");
                        //playerInventory.AddItemToInventory(weaponItem);
                        gameObject.GetComponent<PlayerInputManager>().interact = false;
                        break;
                    }

                    if (weaponItem.CompareTag("Axe") && weaponItem.activeSelf == true)
                    {
                        print("Pick up axe");
                        //playerInventory.AddItemToInventory(weaponItem);
                        gameObject.GetComponent<PlayerInputManager>().interact = false;
                        break;
                    }

                    if (weaponItem.CompareTag("Dagger") && weaponItem.activeSelf == true)
                    {
                        print("Pick up dagger");
                        //playerInventory.AddItemToInventory(weaponItem);
                        gameObject.GetComponent<PlayerInputManager>().interact = false;
                        break;
                    }
                }
            }
        }

        gameObject.GetComponent<PlayerInputManager>().interact = false;
        return weaponItem;
    }*/

    /*private void AddItemToInventory(GameObject weaponObject)
    {
        if (weaponSlot.childCount >= 1)
        {
            weaponObject.tag = player.tag + weaponItem.tag;
            player.GetComponent<PlayerInventory>().ItemInventory.Add(weaponObject);
            weaponItem.SetActive(false);
        }
        else
        {
            weaponObject.tag = player.tag + weaponItem.tag;
            weaponObject.name = player.tag + weaponItem.tag;
            weaponObject.transform.position = weaponSlot.transform.position;
            weaponObject.transform.rotation = weaponSlot.transform.rotation;
            weaponObject.transform.SetParent(weaponSlot);
            weaponObject.SetActive(true);
        }
    }

    private void PlayerEquipAndSwitchWeapon()
    {
        player.GetComponent<PlayerInventory>().ItemInventory.IndexOf(weaponItem);
    }*/

    private void PlayerInteract()
    {
        if (playerInputManager.select)
        {
            interactable = GetInteractableObjects();
            if (canInteract == true)
            {

                isInteracting = true;
                interactable.Interact(transform);
            }
            else if (canInteract == false)
            {
                isInteracting = false;
                return;
            }
        }
    }

    public void InteractionAnimation()
    {
        if (interactable.GetAnimationClip() != null)
        {
            AnimationsManager.instance.PlayAnimation(playerInteractionAnimation, interactable.GetAnimationClip(), .1f);
        }
    }

    public void SetInteractionStatus()
    {
        isInteracting = false;
    }

    private void FaceInteractable()
    {
        Vector3 lookAtInteractableDirection = interactable.GetInteractionTransform().position - transform.position;

        if (isInteracting)
        {
            Quaternion rotateToInteractable = Quaternion.LookRotation(new Vector3(lookAtInteractableDirection.x, 0, lookAtInteractableDirection.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateToInteractable, .05f);
        }
    }

    public IInteractable GetInteractableObjects()
    {
        // Creating a list to cycle through all the interactable objects that the player is colliding with and adding said colliders to the list
        List<IInteractable> interactablesList = new List<IInteractable>();
        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), sphereRadius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.TryGetComponent(out IInteractable interactable))
            {
                interactablesList.Add(interactable);
            }
        }

        // Iterating through the above list again and checking for closest object
        // Checking if first object is found and setting it to the closest if so
        // Comparing if the new object is closer than previous closest, and if so, setting it as the new closest object to interact with
        // Return the new closest object
        IInteractable closestInteractableNPC = null;
        foreach (IInteractable interactable in interactablesList)
        {
            if (closestInteractableNPC == null)
            {
                closestInteractableNPC = interactable;
            }

            else if (Vector3.Distance(transform.position, interactable.GetInteractionTransform().position)
                < Vector3.Distance(transform.position, closestInteractableNPC.GetInteractionTransform().position))
            {
                closestInteractableNPC = interactable;
            }
        }
        return closestInteractableNPC;
    }

    public bool GetCanInteractBool()
    {
        return canInteract;
    }
}
