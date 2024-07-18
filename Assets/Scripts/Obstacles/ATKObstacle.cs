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
                StartCoroutine(DecreaseATK());
            }
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator DecreaseATK()
    {
        isActive = true;
        remainingTime = minusATKTime;

        PlayerController.atk -= ATK;

        while (remainingTime > 0)
        {
            yield return null;
            remainingTime -= Time.deltaTime;
        }

        PlayerController.atk = originalATK;
        isActive = false;
        
        Destroy(gameObject);
    }
}
