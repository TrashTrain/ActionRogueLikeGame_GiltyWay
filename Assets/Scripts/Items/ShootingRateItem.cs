using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRateItem : Item
{
    public float shootingRate = 0.2f;
    public GunController gun; 
    
    protected override void takeItem()
    {
        Debug.Log("Get Shooting Rate Item");
        gun.GetComponent<GunController>().maxRate += shootingRate;
    }
}
