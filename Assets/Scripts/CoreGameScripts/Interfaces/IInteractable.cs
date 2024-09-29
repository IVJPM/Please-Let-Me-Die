using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    void Interact(Transform interactorTransform);
    string GetInteractionText();

    Transform GetInteractionTransform();

    bool IsInteracting();

    AnimationClip GetAnimationClip();
}
