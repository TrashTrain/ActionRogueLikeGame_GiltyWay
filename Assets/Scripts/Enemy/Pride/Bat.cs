using System;
using UnityEngine;

public class Bat : GeneralMonsterTest
{
    protected override void Attack()
    {
        if (generalMonsterData.targetTransform.position != null)
        {
            var targetPos = generalMonsterData.targetTransform.position;
            
            
            Vector2 attackDir = new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).normalized;
            rb.velocity = Vector2.zero;
            rb.AddForce(attackDir * 5f, ForceMode2D.Impulse);
        }
        
        Invoke("Attack", 1f);
    }

    
    
    protected override void AttackUpdate()
    {
        base.AttackUpdate();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<PlayerController>().GetDamaged( generalMonsterData.attackDamage, this.gameObject,
                (((other.transform.position.x > transform.position.x) ? Vector2.right : Vector2.left) + 0.5f * Vector2.up).normalized *  generalMonsterData.knockBackPower);
            
            Destroy(this.gameObject);
        }
        
    }
}