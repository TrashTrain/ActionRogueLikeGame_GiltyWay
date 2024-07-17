using UnityEngine;

public class Skull : GeneralMonster
{
    protected override void Attack()
    {
        Debug.Log("AttackSkull");
        base.Attack();
    }
}