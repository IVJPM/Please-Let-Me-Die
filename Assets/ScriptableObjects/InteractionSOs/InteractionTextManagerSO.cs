using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionTextManagerSO", menuName = "InteractionTextSO/InteractionDialogue")]

public class InteractionTextManagerSO : ScriptableObject
{
    [Header("Dialogue Options")]
    [SerializeField] string npcName;
    [TextArea(3, 10)]
    public List<string> npcDialogue;
    int currentDialogue;
    public string InitialMeetingDialogue(string initialDialogue)
    {
        if (npcDialogue.Count > 0)
        {
            npcDialogue.Clear();
        }
        npcDialogue.Add(initialDialogue);
        return initialDialogue;
    }

    public List<string> AdjustDialogueOptions(List<string> dialogueOptions)
    {
        return dialogueOptions;
    }
}
