using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPItem : Item
{
    public float CP;
    
    protected override void takeItem()
    {
        Debug.Log("Get CP Item");
    }
}
