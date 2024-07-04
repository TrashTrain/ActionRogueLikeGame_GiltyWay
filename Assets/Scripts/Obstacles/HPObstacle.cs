using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObstacle : MonoBehaviour
{
    public int dmg;
    public PlayerController player;

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
            Vector2 bounceDirection = new Vector2(bounceForce,bounceForce);

            other.gameObject.GetComponent<PlayerController>().GetDamaged(dmg, gameObject, bounceDirection);
            
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
