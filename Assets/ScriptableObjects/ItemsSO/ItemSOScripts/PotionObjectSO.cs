using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Type", menuName = "Inventory System/Items/Potion")]
public class PotionObjectSO : ItemObjectsSO
{
    [SerializeField] int healthAdjustment;
    private void Awake()
    {
        itemType = ItemTypes.Potion;
    }
}
