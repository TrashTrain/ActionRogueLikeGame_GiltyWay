using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Status, PassiveSkill, ActiveSkill
}
public enum StatusType
{
    HP, ATK, DEF, SPD
}
[CreateAssetMenu(fileName = " New SlotData", menuName ="CustomData/Create SlotData")]
public class SlotData : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;
    public int statusValue;
    public TMP_FontAsset font;
    
    [TextArea]
    public string itemDescription;
    public ItemType type;
    public StatusType status;
}
