using UnityEngine;

public class Projectile : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private float knockBackPower = 50f;
    [SerializeField] private float attackDamage = 2f;
    public float AttackDamage => attackDamage;
    

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        sprite.flipX = (rb.velocity.x > 0) ? false : true;
        
        Invoke("DestroyEvent", 4f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9) return;
        
        if (other.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<PlayerController>().GetDamaged(AttackDamage, this.gameObject,
                (((other.transform.position.x > transform.position.x) ? Vector2.right : Vector2.left) + 0.5f * Vector2.up).normalized * knockBackPower);
        }
        
        DestroyEvent();
    }
    

    public void DestroyEvent()
    {
        Destroy(this.gameObject);
    }
}

