using UnityEngine;

public class Bat : GeneralMonsterTest
{
    [SerializeField] private GameObject sonicWavePrefab;
    
    protected override void StateInit()
    {
        base.StateInit();
        
    }
    protected override bool TransitionCheck()
    {
        return base.TransitionCheck();
    }
    

    protected override void Attack()
    {
        Debug.Log("AttackBat");
        base.Attack();
        
        if (generalMonsterData.targetTransform.position != null)
        {
            var targetPos = generalMonsterData.targetTransform.position;
            
            Vector2 attackDir = new Vector2(targetPos.x - rb.position.x, targetPos.z - rb.position.y).normalized;
            sprite.flipX = (attackDir.x < 0) ? true : false;

            GameObject bullet = Instantiate(sonicWavePrefab, transform.position + transform.forward, Quaternion.FromToRotation(transform.position, targetPos));
            
            bullet.GetComponent<Rigidbody2D>().AddForce(  generalMonsterData. attackSpeed * attackDir , ForceMode2D.Impulse);
        }
    }
}