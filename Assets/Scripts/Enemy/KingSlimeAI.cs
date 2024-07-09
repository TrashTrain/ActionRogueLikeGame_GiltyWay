using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum KingSlimeKind
{
    Green,
    Red,
    Blue
}

public class KingSlimeAI : MonoBehaviour
{
    [Header("Ref")]
    public Transform playerTransform;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Common")] 
    public bool isReady = false;
    public float hp = 100f;
    public float moveSpeed = 10f;
    private float attackDamage = 3f;
    public float AttackDamage => attackDamage;
    
    public float attackSpeed;
    public float preAttackCT;
    public float postAttackCT;
    public KingSlimeKind kingSlimeKind;
    
    [Header("Green")]
    public float attackGreenSpeed = 10f;
    public float attackGreenDamage = 5f;
    public float preAttackGreenCT = 0.5f;
    public float postAttackGreenCT = 1f;
    
    [Header("Red")]
    public float attackRedSpeed = 30f;
    public float attackRedDamage = 10f;
    public float preAttackRedCT = 2f;
    public float postAttackRedCT = 3f;
    
    [Header("Blue")]
    public float attackBlueSpeed = 2f;
    public float attackBlueDamage = 5f;
    public float preAttackBlueCT = 2f;
    public float postAttackBlueCT = 1f;
    
    [Header("Obstacle")]
    public float ObstacleRaycastDistance = 5f;
    public LayerMask groundLayer;
    
    private SlimeState currentState = SlimeState.Idle;
    private Vector2 moveDirection = Vector2.left; // 초기 이동 방향
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        groundLayer = 1 << 7;
    }

    private void Start()
    {
        TurnToPlayer();
    }

    private void Update()
    {
        if (!isReady) return;
        
        switch (currentState)
        {
            case SlimeState.Idle:
                Idle();
                break;
        }
    }

    private void LateUpdate()
    {
        if(!isReady) return;
        if (DetectObstacle() == true)
        {
            if (currentState == SlimeState.Idle)
            {
                TurnBack();
            }
        }
    }

    public void ReadyEvent()
    {
        isReady = true;
        
    }

    private void TurnToPlayer()
    {
        if (isReady)
        {
            moveDirection = (playerTransform.position.x >= transform.position.x) ? Vector2.right : Vector2.left;
        }
        
        Invoke("TurnToPlayer", 1f);
    }
    
    private void Idle()
    {
        rb.transform.Translate( moveSpeed * Time.deltaTime * moveDirection);
    }
    
    private void TurnBack()
    {
        moveDirection = -moveDirection;
        sprite.flipX = (moveDirection.x < 0 ) ? true : false;
    }

    private bool DetectObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.transform.position, moveDirection, ObstacleRaycastDistance, groundLayer);
        Debug.DrawRay(rb.transform.position, (moveDirection) * ObstacleRaycastDistance, Color.blue);
        
        if (hit.collider != null) return true;

        return false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (currentState == SlimeState.Death) return;
        
        
        if (other.gameObject.layer == 9)
        {
            TurnBack();
        }
        
        if (other.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<PlayerController>().GetDamaged(AttackDamage, this.gameObject, Vector2.up * 10);
        }
        
    }
    
    
    public void StopRoulette()
    {
        animator.SetTrigger("PreAttack");
    }
    
    public void ResetEvent()
    {
        currentState = SlimeState.Idle;
        Invoke("StopRoulette", Random.Range(3, 4));
    }

    public void SetAttackTrue(){ animator.SetBool("Attack", true);}
    public void SetAttackFalse(){ animator.SetBool("Attack", false);}

    public void PreAttackEvent()
    {
        currentState = SlimeState.Attack;
        Invoke("SetAttackTrue", preAttackCT);
    }

    public void SyncCommonData(float atkSpeed, float atkDamage, float preAtkCT, float postAtkCT)
    {
        attackSpeed = atkSpeed;
        attackDamage = atkDamage;
        preAttackCT = preAtkCT;
        postAttackCT = postAtkCT;
        
        PreAttackEvent();
    }
    
    public void PreAttackGreenEvent()
    {
        kingSlimeKind = KingSlimeKind.Green;
        SyncCommonData(attackGreenSpeed, attackGreenDamage, preAttackGreenCT, postAttackGreenCT);
        
    }
    public void PreAttackRedEvent()
    {
        kingSlimeKind = KingSlimeKind.Red;
        SyncCommonData(attackRedSpeed, attackRedDamage, preAttackRedCT, postAttackRedCT);
    }
    public void PreAttackBlueEvent()
    {
        kingSlimeKind = KingSlimeKind.Blue;
        SyncCommonData(attackBlueSpeed, attackBlueDamage, preAttackBlueCT, postAttackBlueCT);
    }
    

    public void PostAttackEvent()
    {
        Invoke("SetAttackFalse", postAttackCT);
    }
    
    private void AttackEvent()
    {
        if (playerTransform.position != null && playerTransform.position.magnitude > 0.01f)
        {
            Vector2 attackDir = new Vector2(playerTransform.position.x - rb.position.x, playerTransform.position.y - rb.position.y).normalized;
            sprite.flipX = (attackDir.x < 0) ? true : false;
            
            rb.AddForce(  attackSpeed * attackDir , ForceMode2D.Impulse);
            
            SoundManager.instance.PlaySound("Slime_Jump", transform.position);
        }
    }

    public void GetDamaged(float damage)
    {
        if (damage <= 0) return;
        if (currentState == SlimeState.Death) return;
        
        //animator.SetTrigger("Hurt");
        //currentState = SlimeState.Hurt;
        SoundManager.instance.PlaySound("Slime_Damaged", transform.position);
        
        this.hp -= damage;
        UIManager.instance.hitDamageInfo.PrintHitDamage(transform, damage);
        
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        currentState = SlimeState.Death;
        animator.SetTrigger("Death");
        SoundManager.instance.PlaySound("Slime_Destroyed", transform.position);
    }

    public void DestroyEvent()
    {
        Destroy(this.gameObject);
    }
    
}
