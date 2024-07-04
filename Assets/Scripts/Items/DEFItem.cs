using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFItem : Item
{
    public int DEF = 2;
    public float plusDEFTime = 5f;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(IncreaseDEF(player));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseDEF(PlayerController player)
    {
        int playerDEF = player.def;
        player.def += DEF;
        
        yield return new WaitForSeconds(plusDEFTime);

        player.def = playerDEF;
        Destroy(gameObject);
    }
}
