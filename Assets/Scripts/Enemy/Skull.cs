using UnityEngine;

public class Skull : MonoBehaviour, IDamageable
{
    [Header("Ref")]
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public Animator animator;

    [Header("General Setting")]
    [SerializeField] private float knockBackPower = 20f;
    [SerializeField] private float hp = 10f;
    [SerializeField] private GeneralMonsterState currentState = GeneralMonsterState.Idle;
    
    [Header("Patrol(Idle) Setting")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float patrolDistance = 6f;
    [SerializeField] private Vector2 patrolPos;
    [SerializeField] private Vector2 moveDirection = Vector2.right;
    [SerializeField] private float obstacleRaycastDistance = 1f;
    
    [Header("Attack Setting")]
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Transform targetTransform = null;
    [SerializeField] private float recognizeRadius = 5f;
    [SerializeField] private float attackSpeed = 10f;
    [SerializeField] private float attackDamage = 2f;
    public float AttackDamage => attackDamage;

    //Constant Variable
    private const int PlayerLayer = 1 << 6;
    private const int GroundLayer = 1 << 7;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        targetLayer = PlayerLayer;

        patrolPos = transform.position;
        
        //null check
        if(rb == null) {Debug.LogError("Bat(RigidBody2D) is null");}
        if(animator == null) {Debug.LogError("Bat(Animator) is null");}
        if(sprite == null) {Debug.LogError("Bat(Sprite) is null");}
        if(targetLayer != PlayerLayer) {Debug.LogError("Bat(targetLayer is not playerLayer)");}
    }

    private void Start()
    {
        //Invoke(nameof(CheckTarget), 1f);
    }

    private void FixedUpdate()
    {
        if (currentState == GeneralMonsterState.Idle)
        {
            Patrol();
        }

        if (currentState == GeneralMonsterState.Attack)
        {
            sprite.flipX = (targetTransform.position.x < transform.position.x);
        }
    }

    private void TurnBack()
    {
        moveDirection = -moveDirection;
        sprite.flipX = (moveDirection.x < 0 );
    }

    private void Patrol()
    {
        if (DetectObstacle())
        {
            TurnBack();
        }
        
        if (moveDirection.x > 0 && Vector2.Distance(transform.position, patrolPos + Vector2.right * patrolDistance / 2) < 0.01f)
        {
            TurnBack();
        } 
        else if(moveDirection.x < 0 && Vector2.Distance(transform.position, patrolPos + Vector2.left * patrolDistance / 2) < 0.01f)
        {
            TurnBack();
        }
        
        rb.transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
    }

    private void CheckTarget()
    {
        if (currentState != GeneralMonsterState.Idle) return;

        Collider2D target = Physics2D.OverlapCircle(rb.position, recognizeRadius, targetLayer);
        if (target != null)
        {
            Debug.Log("Attack!");
            targetTransform = target.transform;
            animator.SetTrigger("Attack");
            currentState = GeneralMonsterState.Attack;
        }
        
        Invoke(nameof(CheckTarget), 1f);
    }
    
    private bool DetectObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.transform.position, moveDirection, obstacleRaycastDistance, GroundLayer);
        Debug.DrawRay(rb.transform.position, (moveDirection) * obstacleRaycastDistance, Color.blue);
        
        if (hit.collider != null) return true;

        return false;
    }
    
    public void GetDamaged(float damage)
    {
        if(damage <= 0) return;
        if(currentState == GeneralMonsterState.Death) return;
        
        //this.hp -= damage;
        UIManager.instance.hitDamageInfo.PrintHitDamage(transform, 0);

        if (hp < 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (currentState == GeneralMonsterState.Death) return;
        
        if (other.gameObject.layer == 9)
        {
            TurnBack();
        }

        if (other.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<PlayerController>().GetDamaged(AttackDamage, this.gameObject,
                (((other.transform.position.x > transform.position.x) ? Vector2.right : Vector2.left) + 0.5f * Vector2.up).normalized * knockBackPower);
        }
    }
}
