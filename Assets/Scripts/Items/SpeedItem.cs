using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpeedItem : Item
{
    public float speed = 2f;
    public float originalSpeed = 5f;
    public float speedPlusTime = 5f;

    private static bool isActive = false;
    private Coroutine speedCoroutine;
    
    public BuffItemController buffItemController;
    public Sprite icon;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            itemGetText.DisplayText("Speed UP!");

            // if (isActive)
            // {
            //     player.speed = originalSpeed;
            // }
            
            speedCoroutine = StartCoroutine(IncreaseSpeed(player));
            
            buffItemController.AddBuff("Speed Up Item", player.speed, speedPlusTime, icon);
            
            if (isActive)
            {
                player.speed = originalSpeed;
                StopCoroutine(speedCoroutine);
                speedCoroutine = StartCoroutine(IncreaseSpeed(player));
            }
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseSpeed(PlayerController player)
    {
        isActive = true;
        player.speed += speed;

        yield return new WaitForSeconds(speedPlusTime);
        
        player.speed = originalSpeed;
        isActive = false;
        Destroy(gameObject);
    }
}
