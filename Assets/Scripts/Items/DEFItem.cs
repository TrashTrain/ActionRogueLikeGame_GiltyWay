using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFItem : Item
{
    public int DEF = 2;
    
    
    protected override void takeItem()
    {
        Debug.Log("Get Defence Item");
        player.GetComponent<PlayerController>().def += DEF;
    }

}
