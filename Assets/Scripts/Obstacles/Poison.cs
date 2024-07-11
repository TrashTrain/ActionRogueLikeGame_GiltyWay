using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public PlayerController player;
    public float dmg = 2f;
    public float dmgTime = 3f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            
            StartCoroutine(DecreaseHp(player));
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator DecreaseHp(PlayerController player)
    {
        float duration = 0f;

        while (duration < dmgTime)
        {
            player.hp -= dmg;
            duration += 1f;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
    
}
