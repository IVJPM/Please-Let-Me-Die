using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Ingredient,
    Potion,
    Tool,
    Weapon,
    Apparel
}
public abstract class ItemObjectsSO : ScriptableObject
{
    public GameObject objectPrefab;
    public ItemTypes itemType;

    [TextArea(10, 15)]
    public string itemDescription;
}
