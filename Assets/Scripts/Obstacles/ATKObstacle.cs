using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKObstacle : Obstacle
{
    public float ATK = 2f;
    public float originalATK = 10f;
    public float minusATKTime = 5f;

    private static bool isActive = false;
    private static float remainingTime = 0f;

    public BuffItemController BuffItemController;
    public Sprite icon;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            if (isActive)
            {
                remainingTime = minusATKTime;
            }
            else
            {
                StartCoroutine(DecreaseATK(player));
            }
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator DecreaseATK(PlayerController player)
    {
        isActive = true;
        remainingTime = minusATKTime;

        player.atk -= ATK;

        while (remainingTime > 0)
        {
            yield return null;
            remainingTime -= Time.deltaTime;
        }
        
        player.atk = originalATK;
        isActive = false;
        
        Destroy(gameObject);
    }
}
