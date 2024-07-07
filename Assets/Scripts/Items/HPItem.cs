using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPItem : Item
{
    public int hp = 2;
    
    // protected override void takeItem()
    // {
    //     Debug.Log("Get HP Item");
    //     player.GetComponent<PlayerController>().hp += hp;
    // }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<PlayerController>().hp += hp;
        Destroy(gameObject);
    }
}
