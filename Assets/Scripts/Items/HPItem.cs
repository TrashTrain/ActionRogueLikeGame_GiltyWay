using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HPItem : Item
{
    public int hp = 2;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        SFXManager.Instance.PlaySound(SFXManager.Instance.getItem);
        player.GetComponent<PlayerController>().hp += hp;
        if (player.GetComponent<PlayerController>().hp >= 50) player.GetComponent<PlayerController>().hp = 50;
        UIManager.instance.playerInfo.SetHp(player.GetComponent<PlayerController>().hp);
        itemGetText.DisplayText("HP Up!");
        Destroy(gameObject);
    }
}
