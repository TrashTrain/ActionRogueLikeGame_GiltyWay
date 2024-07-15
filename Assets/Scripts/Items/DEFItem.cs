using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEFItem : Item
{
    public float DEF = 2;
    public float originalDEF = 5f;
    public float plusDEFTime = 5f;

    private static bool isActive = false;
    private static float remainingTime = 0f;
    
    public BuffItemController buffItemController;
    public Sprite icon;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            SFXManager.Instance.PlaySound(SFXManager.Instance.getItem);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            itemGetText.DisplayText("Defense Power Up!");
            
            if (isActive)
            {
                // 아이템 중복으로 획득하면 타이머만 갱신
                remainingTime = plusDEFTime;
            }
            else
            {
                StartCoroutine(IncreaseDEF(player));
            }
            
            // 아이템 버프창에 올리기
            buffItemController.AddBuff("DEF Up Item", player.def, plusDEFTime, icon);
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseDEF(PlayerController player)
    {
        isActive = true;    // 아이템 중복 확인용
        remainingTime = plusDEFTime;
        
        player.def += DEF;
        
        while (remainingTime > 0)
        {
            yield return null;
            remainingTime -= Time.deltaTime;
        }
        
        player.def = originalDEF;
        isActive = false;   // 아이템 효과 끝

        Destroy(gameObject);
    }
}
