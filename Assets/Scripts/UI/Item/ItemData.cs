using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemType
{
    Consumable
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "CustomData/Create Item Data")]
public class ItemData : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;

    [TextArea] 
    public string itemDesc;
    public string itemDuration;
    public ItemType type;
    
}
