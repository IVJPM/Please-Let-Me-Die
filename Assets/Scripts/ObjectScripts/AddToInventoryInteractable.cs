using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddToInventoryInteractable : MonoBehaviour, IInteractable
{
    [field: SerializeField] public AnimationClip objectInteractClip;
    [SerializeField] bool isInteracting;

    [SerializeField] string interactionButtonText;

    private Transform interactionTarget;

    public void Interact(Transform interactorTransform)
    {
        isInteracting = true;
        StartCoroutine(AddToInventoryVisual());
    }

    IEnumerator AddToInventoryVisual()
    {
        yield return new WaitForSecondsRealtime(1.35f);
        Destroy(gameObject);
        isInteracting = false;
    }

    public string GetInteractionText()
    {
        return interactionButtonText;
    }

    public Transform GetInteractionTransform()
    {
        return transform;
    }

    public bool IsInteracting()
    {
        return isInteracting;
    }

    public AnimationClip GetAnimationClip()
    { 
        return objectInteractClip; 
    }
}
