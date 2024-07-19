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
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            SFXManager.Instance.PlaySound(SFXManager.Instance.getItem);
            
            player.GetComponent<PlayerController>().hp += hp;
            if (player.GetComponent<PlayerController>().hp >= 50) player.GetComponent<PlayerController>().hp = 50;

            UIManager.instance.playerInfo.SetHp(player.GetComponent<PlayerController>().hp);
            
            // UIManager.instance.hpUpInfo.PrintHpUp(player.transform, hp);      // UI manager 수정 후에 주석 풀기
            
            // UIManager.instance.itemGetText.DisplayText("HP +2 Up!");
            
            Destroy(gameObject);
        }
    }
}
