using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFItem : Item
{
    public int DEF = 2;
    public float plusDEFTime = 5f;

    public BuffItemController buffItemController;
    public Sprite icon;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            itemGetText.DisplayText("Defense Power Up!");
            
            StartCoroutine(IncreaseDEF(player));
            
            // 아이템 버프창에 올리기
            buffItemController.AddBuff("DEF Up Item", player.def, plusDEFTime, icon);
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseDEF(PlayerController player)
    {
        float playerDEF = player.def;
        player.def += DEF;
        
        yield return new WaitForSeconds(plusDEFTime);

        player.def = playerDEF;
        Destroy(gameObject);
    }
}
