using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public float raycastDistance = 1f; // 발판 끝을 감지하기 위한 레이캐스트 거리
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
                moveDirection = -moveDirection;
                sprite.flipX = (moveDirection.x < 0 ) ? true : false;
            }

            if (currentState == SlimeState.Attack)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private bool DetectCliff()
    {
        // 발판의 끝을 감지
        RaycastHit2D hit = Physics2D.Raycast(rb.transform.position, moveDirection + Vector2.down, raycastDistance, groundLayer);
        Debug.DrawRay(rb.transform.position, (moveDirection + Vector2.down) * raycastDistance, Color.red);

        if (hit.collider == null) return true;

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
