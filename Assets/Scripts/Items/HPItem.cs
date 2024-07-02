using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    public float energy;
    
    protected override void takeItem()
    {
        Debug.Log("Get HP Item");
    }
}
