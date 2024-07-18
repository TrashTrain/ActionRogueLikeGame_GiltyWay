using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPItem : Item
{
    public int CP = 2;
    public float originalCP = 5f;
    public float plusCPTime = 5f;

    private static bool isActive = false;
    private static float remainingTime = 0f;
    
    public BuffItemController buffItemController;
    public Sprite icon;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            SFXManager.Instance.PlaySound(SFXManager.Instance.getItem);

            //itemGetText.DisplayText("Attack Power Up!");
            UIManager.instance.itemGetText.DisplayText("Attack Power Up!");
            
            if (isActive)
            {
                remainingTime = plusCPTime;
            }
            else
            {
                StartCoroutine(IncreaseCP());
            }

            UIManager.instance.buffItemController.AddBuff("ATK Up Item", PlayerController.atk, plusCPTime, icon);
            //buffItemController.AddBuff("ATK Up Item", player.atk, plusCPTime, icon);
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseCP()
    {
        isActive = true;
        remainingTime = plusCPTime;
        
        PlayerController.atk += CP;

        while (remainingTime > 0)
        {
            yield return null;
            remainingTime -= Time.deltaTime;
        }
        
        PlayerController.atk = originalCP;
        isActive = false;
        
        Destroy(gameObject);
    }
}
