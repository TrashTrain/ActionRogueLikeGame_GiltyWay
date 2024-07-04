using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObstacle : MonoBehaviour
{
    public int dmg;
    public PlayerController player;

    public float bounceForce;
    private Color originalColor;            //장애물 원래 색
    public Color hitColor = Color.red;    //캐릭터가 장애물에 부딪혔을 때 바뀌는 색
    
    private float changeTime = 0.5f;        //장애물 색 유지시간

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            player.GetComponent<PlayerController>().hp -= dmg;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                Vector2 bounceDirection = new Vector2(rb.position.x-transform.position.x, rb.position.y-transform.position.y).normalized;
                rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }
            
            StartCoroutine(ChangeColor());
        }
    }
    
    IEnumerator ChangeColor()
    {
        spriteRenderer.color = hitColor;
        
        yield return new WaitForSeconds(changeTime);

        spriteRenderer.color = originalColor;
    }
}
