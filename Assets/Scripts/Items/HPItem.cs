using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    public int energy = 2;
    //public PlayerController player;
    
    protected override void takeItem()
    {
        Debug.Log("Get HP Item");
        player.GetComponent<PlayerController>().hp += energy;
    }
}
