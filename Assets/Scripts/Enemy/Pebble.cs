using UnityEngine;

public class Pebble : GeneralMonster
{
    protected override void Attack()
    {
        Debug.Log("AttackPebble");
        base.Attack();
    }
}
