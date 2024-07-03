using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPItem : Item
{
    public int CP = 2;
    //public PlayerController player;
    
    protected override void takeItem()
    {
        Debug.Log("Get CP Item");
        player.GetComponent<PlayerController>().atk += CP;
    }
}
