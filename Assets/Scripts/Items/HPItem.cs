using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HPItem : Item
{
    public int hp = 2;
    
    public bool isEternal = false;
    public float term = 5f;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            
            SoundManager.instance.PlaySound("Get_Item", transform);
            // SFXManager.Instance.PlaySound(SFXManager.Instance.getItem);

            if (player.hp >= player.maxhp)
            {
                if (!isEternal)
                {
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    StartCoroutine(RecreateItem());
                    return;
                }
            }
            else
            {
                float originalHp = player.hp;
                
                player.hp += hp;
                
                if (player.hp > player.maxhp)
                {
                    player.hp = player.maxhp;
                    float increase = player.hp - originalHp;
                    UIManager.instance.hpInfo.PrintHpUp(player.transform, increase); 
                }
                else
                {
                    UIManager.instance.hpInfo.PrintHpUp(player.transform, hp); 
                }
                
                UIManager.instance.playerInfo.SetHp(player.hp);
            }

            if (!isEternal)
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(RecreateItem());
            }
        }
    }

    IEnumerator RecreateItem()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        
        yield return new WaitForSeconds(term);
        
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
