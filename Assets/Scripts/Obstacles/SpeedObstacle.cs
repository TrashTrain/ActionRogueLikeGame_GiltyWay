using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObstacle : MonoBehaviour
{
    public PlayerController player;
    
    public float speed = 2f;
    public float originalSpeed = 5f;
    public float minusSpeedTime = 5f;
    
    public ItemGetText itemGetText;
    
    private static bool isActive = false;
    private static float remainingTime = 0f;

    public BuffItemController buffItemController;
    public Sprite icon;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            //itemGetText.DisplayText("Slow Down!");
            UIManager.instance.itemGetText.DisplayText("Slow Down!");
            
            if (isActive)
            {
                // 아이템 중복으로 획득하면 타이머만 갱신
                remainingTime = minusSpeedTime;
            }
            else
            {
                StartCoroutine(DecreaseSpeed(player));
            }
            
            // buffItemController.AddBuff("Slow Down Item", player.speed, minusSpeedTime, icon);
            UIManager.instance.buffItemController.AddBuff("Slow Down Item", player.speed, minusSpeedTime, icon);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator DecreaseSpeed(PlayerController player)
    {
        isActive = true;
        remainingTime = minusSpeedTime;
        
        player.speed -= speed;
        
        while (remainingTime > 0)
        {
            yield return null;
            remainingTime -= Time.deltaTime;
        }
        
        player.speed = originalSpeed;
        isActive = false;
        
        Destroy(gameObject);
    }
}
