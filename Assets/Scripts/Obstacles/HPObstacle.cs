using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObstacle : MonoBehaviour
{
    public int dmg;

    private float bounceForce = 20f;
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
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            
            Vector2 bounceDirection = new Vector2(bounceForce, bounceForce);

            player.GetDamaged(dmg, gameObject, bounceDirection);

            StartCoroutine(ChangeColor(this));

        }
    }
    
    IEnumerator ChangeColor(HPObstacle hpObstacle)
    {
        spriteRenderer.color = hitColor;
        
        hpObstacle.GetComponent<BoxCollider2D>().isTrigger = true;  // 한번 hp 손상되었으면 지나갈 수 있도록
        yield return new WaitForSeconds(changeTime);
        
        hpObstacle.GetComponent<BoxCollider2D>().isTrigger = false;
        spriteRenderer.color = originalColor;
    }
}
