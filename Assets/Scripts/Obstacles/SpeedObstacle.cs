using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObstacle : MonoBehaviour
{
    public PlayerController player;
    public float speed = 2f;
    public float minusSpeedTime = 5f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(DecreaseSpeed(player));

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator DecreaseSpeed(PlayerController player)
    {
        float playerSpeed = player.speed;
        player.speed -= speed;
        
        yield return new WaitForSeconds(minusSpeedTime);

        player.speed = playerSpeed;
        Destroy(gameObject);
    }
}
