using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PlayerInteractionsUI : MonoBehaviour
{
    // Will be placed on a Canvas to show interaction texts between player and other objects
    [SerializeField] GameObject canvasInteractionContainer;
    [SerializeField] GameObject dialogueInteractionContainer;
    [SerializeField] PlayerInteractable playerInteractable;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Update()
    {
        if (playerInteractable.GetInteractableObjects() != null)
        {
            ShowInteractionText(playerInteractable.GetInteractableObjects());
        }
        else 
        {
            HideInteractionText(playerInteractable.GetInteractableObjects());
        }
    }

    private void ShowInteractionText(IInteractable interactables)
    {
        IInteractable interactable = interactables;
        if(playerInteractable.GetCanInteractBool() == true && interactable.IsInteracting() == true && interactable.GetInteractionTransform().gameObject.TryGetComponent(out NPCInteractions npc))
        {
            dialogueInteractionContainer.SetActive(true);
        }
        else
        {
            dialogueInteractionContainer.SetActive(false);
        }
        canvasInteractionContainer.SetActive(true);
        textMeshProUGUI.text = interactables.GetInteractionText();
    }

    private void HideInteractionText(IInteractable interactables)
    {
        IInteractable interactable = interactables;
        if(playerInteractable.GetCanInteractBool() == false)
        {
            dialogueInteractionContainer.SetActive(false);
        }
        canvasInteractionContainer.SetActive(false);
    }
}
