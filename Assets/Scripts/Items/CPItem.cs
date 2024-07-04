using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPItem : Item
{
    public int CP = 2;
    public float plusCPTime = 5f;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(IncreaseCP(player));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseCP(PlayerController player)
    {
        int playerAtk = player.atk;
        player.atk += CP;
        
        yield return new WaitForSeconds(plusCPTime);

        player.atk = playerAtk;
        Destroy(gameObject);
    }
}
