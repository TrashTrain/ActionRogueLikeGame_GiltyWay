using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public enum SlimeState
{
    Idle,
    Attack,
    Hurt,
    Death
}

public class GreenSlimeAI : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public Animator animator;
    
    public float moveSpeed = 2f;
    public float attackSpeed = 3f;
    public float CliffRaycastDistance = 1f; // 발판 끝을 감지하기 위한 레이캐스트 거리
    public float ObstacleRaycastDistance = 1f;
    public LayerMask groundLayer;
    
    private Vector2 playerPos;
    
    private SlimeState currentState = SlimeState.Idle;
    private Vector2 moveDirection = Vector2.right; // 초기 이동 방향

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        groundLayer = 1 << 7;
    }

    private void Update()
    {
        switch (currentState)
        {
            case SlimeState.Idle:
                Idle();
                break;
            case SlimeState.Attack:
                //Attack();
                break;
            case SlimeState.Hurt:
                // Hurt 상태 처리 로직 (생략)
                break;
            case SlimeState.Death:
                // Death 상태 처리 로직 (생략)
                break;
        }
    }

    private void LateUpdate()
    {
        // 발판의 끝에 도달하면 이동 방향을 반대로 변경
        if (DetectCliff() == true)
        {
            if (currentState == SlimeState.Idle)
            {
                TurnBack();
            }

            if (currentState == SlimeState.Attack)
            {
                //rb.velocity = new Vector2(0, rb.velocity.y);
            }
            
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (DetectObstacle() == true)
        {
            if (currentState == SlimeState.Idle)
            {
                TurnBack();
            }
        }
    }

    private void TurnBack()
    {
        moveDirection = -moveDirection;
        sprite.flipX = (moveDirection.x < 0 ) ? true : false;
    }

    private bool DetectCliff()
    {
        // 발판의 끝을 감지
        RaycastHit2D hit = Physics2D.Raycast(rb.transform.position, moveDirection + 2* Vector2.down, CliffRaycastDistance, groundLayer);
        Debug.DrawRay(rb.transform.position, (moveDirection + Vector2.down) * CliffRaycastDistance, Color.red);

        if (hit.collider == null) return true;

        return false;
    }

    private bool DetectObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.transform.position, moveDirection, ObstacleRaycastDistance, groundLayer);
        Debug.DrawRay(rb.transform.position, (moveDirection) * ObstacleRaycastDistance, Color.blue);
        
        if (hit.collider != null) return true;

        return false;
    }
    
    private void Idle()
    {
        // 이동
        rb.transform.Translate( moveSpeed * Time.deltaTime * moveDirection);
        
        
    }

    private void JumpAttack()
    {
        if (playerPos != null && playerPos.magnitude > 0.01f)
        {
            animator.SetTrigger("Attack");
            Vector2 attackDir = new Vector2(playerPos.x - rb.position.x, playerPos.y - rb.position.y).normalized;
            sprite.flipX = (attackDir.x < 0) ? true : false;
            rb.AddForce(  attackSpeed * attackDir , ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            TurnBack();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerPos = other.transform.position;
            animator.SetTrigger("Attack");
            StartAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerPos = Vector2.zero;
        }
    }
    
    public void StartAttack()
    {
        currentState = SlimeState.Attack;
    }

    public void EndAttack()
    {
        currentState = SlimeState.Idle;
    }
}
