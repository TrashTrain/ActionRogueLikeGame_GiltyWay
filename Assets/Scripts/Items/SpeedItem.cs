using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item
{
    public float speed;

    protected override void takeItem()
    {
        Debug.Log("Get Speed Item");    
    }
}
