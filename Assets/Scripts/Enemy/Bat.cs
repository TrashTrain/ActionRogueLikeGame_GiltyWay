using UnityEngine;

public class Bat : GeneralMonster
{
    protected override void Attack()
    {
        Debug.Log("AttackBat");
        base.Attack();
    }
}