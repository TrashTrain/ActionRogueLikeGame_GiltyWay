using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedItem : Item
{
    public float speed = 2f;
    public float speedPlusTime = 5f;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(IncreaseSpeed(player));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator IncreaseSpeed(PlayerController player)
    {
        float playerSpeed = player.speed;
        player.speed += speed;
        
        yield return new WaitForSeconds(speedPlusTime);

        player.speed = playerSpeed;
        Destroy(gameObject);
    }
}
