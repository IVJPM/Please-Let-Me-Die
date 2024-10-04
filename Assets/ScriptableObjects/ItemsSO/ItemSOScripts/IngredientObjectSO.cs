using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient Type", menuName = "Inventory System/Items/Ingredient")]
public class IngredientObjectSO : ItemObjectsSO
{
    private void Awake()
    {
        itemType = ItemTypes.Ingredient;
    }
}
