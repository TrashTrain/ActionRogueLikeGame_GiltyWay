using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpeedItem : Item
{
    public BuffPanelSystem buffPanelSystem;

    public ItemData speedItemData;
    public float speed = 2f;
    public float speedPlusTime = 5f;

    SpriteRenderer spriteRenderer;

    public BuffText buffText;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            //string itemName = gameObject.name;
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            
            //아이템이랑 부딪힐 때마다 itemdata 에 추가
            buffPanelSystem.itemDataGroup.Add(speedItemData);
            
            StartCoroutine(IncreaseSpeed(player));
            
            buffText.AddBuff("Speed Item", player.speed, speedPlusTime);
            //speedItemData.AddBuff("Speed Item", player.speed, speedPlusTime);
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseSpeed(PlayerController player)
    {
        float playerSpeed = player.speed;
        player.speed += speed;
        
        yield return new WaitForSeconds(speedPlusTime);

        player.speed = playerSpeed;
        Destroy(gameObject);
        
    }
}
