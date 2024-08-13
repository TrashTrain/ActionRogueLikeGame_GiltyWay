using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHpObstacle : MonoBehaviour
{
    private PlayerController player;

    // public float dropDistance = 2f;

    private Rigidbody2D rb;
    
    public float range; // 플레이어 감지용
    public float gravityScale = 4f;
    public float dmg;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        DetectPlayer();
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= range)
            {
                rb.gravityScale = gravityScale;
            }
        }
    }

      void DetectPlayer()
      {
           RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, range, LayerMask.GetMask("Player"));
        
           if (hit.collider != null)
           {
               player = hit.collider.GetComponent<PlayerController>();
           }
           else
           {
               player = null;
           }
      }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 3|| other.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 6)
        {
            SoundManager.instance.PlaySound("Obstacle_Attack", transform);
            other.gameObject.GetComponent<PlayerController>().GetDamaged(dmg, gameObject, new Vector2(0f,0f));
            Destroy(gameObject);
        }
    }
}
