using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public PlayerController player;
    public float dmg = 2f;
    public float dmgTime = 3f;

    // private static bool isActive = false;
    // private static float remainingTime = 0f;

    // public BuffItemController buffItemController;
    // public Sprite icon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            // -------------------
            // if (isActive)
            // {
            //     remainingTime = dmgTime;
            // }
            // else
            // {
            //     StartCoroutine(DecreaseHp(player));
            // }

            // buffItemController.AddBuff("Poisonous Mushroom", player.hp, dmgTime, icon);
            // ----------------------
            StartCoroutine(DecreaseHp(player));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            if (player.hp <= 0)
            {
                Debug.Log("GameOver");
                Destroy(player);
            }
        }
    }

    IEnumerator DecreaseHp(PlayerController player)
    {
        // isActive = true;
        // remainingTime = dmgTime;

        float duration = 0f;

        // while (remainingTime > 0)
        // {
        //     if (remainingTime % 2 != 0)
        //     {
        //         player.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
        //     }
        //     else
        //     {
        //         player.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);
        //     }
        //     player.hp -= dmg;
        //     remainingTime -= Time.deltaTime;
        //     UIManager.instance.playerInfo.SetHp(player.hp);
        // }
        //
        // isActive = false;

        // --------------

        while (duration < dmgTime)
        {
            if (duration % 2 != 0)
            {
                player.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
            }
            else
            {
                player.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);
            }
            
            player.hp -= dmg;
            UIManager.instance.playerInfo.SetHp(player.hp);
            duration += 1f;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
