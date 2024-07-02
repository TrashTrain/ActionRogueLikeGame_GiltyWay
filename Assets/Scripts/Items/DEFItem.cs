using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFItem : Item
{
    public float DEF;
    
    protected override void takeItem()
    {
        Debug.Log("Get Defence Item");    
    }

}
