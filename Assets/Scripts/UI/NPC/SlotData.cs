using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Status, PassiveSkill, ActiveSkill
}
[CreateAssetMenu(fileName = " New SlotData", menuName ="CustomData/Create SlotData")]
public class SlotData : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;

    [TextArea]
    public string itemDescription;
    public ItemType type;
}
