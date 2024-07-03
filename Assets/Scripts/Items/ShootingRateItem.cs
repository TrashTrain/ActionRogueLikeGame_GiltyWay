using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRateItem : Item
{
    public float ShootingRate;
    //public PlayerController player;
    
    protected override void takeItem()
    {
        Debug.Log("Get Shooting Rate Item");
        //player.GetComponent<PlayerController>().shootingRate += ShootingRate;
    }
}
