using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPItem : Item
{
    public int CP = 2;
    public float plusCPTime = 5f;

    public BuffItemController buffItemController;
    public Sprite icon;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            itemGetText.DisplayText("Attack Power Up!");
            
            StartCoroutine(IncreaseCP(player));

            buffItemController.AddBuff("ATK Up Item", CP, plusCPTime, icon);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseCP(PlayerController player)
    {
        float playerAtk = player.atk;
        player.atk += CP;

        yield return new WaitForSeconds(plusCPTime);

        player.atk = playerAtk;
        Destroy(gameObject);
    }
}
