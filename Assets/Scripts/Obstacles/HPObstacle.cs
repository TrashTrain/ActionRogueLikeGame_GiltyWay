using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObstacle : MonoBehaviour
{
    public int dmg;
    public PlayerController player;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            player.GetComponent<PlayerController>().hp -= dmg;
            //Destroy(gameObject);
        }
    }
}
