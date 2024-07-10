using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpeedItem : Item
{
    public float speed = 2f;
    public float speedPlusTime = 5f;

    public BuffItemController buffItemController;
    public Sprite icon;
    
    SpriteRenderer spriteRenderer;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            itemGetText.DisplayText("Speed UP!");
            
            StartCoroutine(IncreaseSpeed(player));
            
            buffItemController.AddBuff("Speed Up Item", player.speed, speedPlusTime, icon);
            
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
