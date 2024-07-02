using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRateItem : Item
{
    public float ShootingRate;
    
    protected override void takeItem()
    {
        Debug.Log("Get Shooting Rate Item");
    }
}
