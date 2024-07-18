using UnityEngine;

public class Bat : GeneralMonsterTest
{
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
    }
}