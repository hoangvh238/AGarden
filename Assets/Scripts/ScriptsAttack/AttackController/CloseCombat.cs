using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloseCombat : Attack
{
    protected override bool CheckAttack()
    {
        if (!this.CanCloseCombat()) return false;
        return base.CheckAttack();
    }

    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        this.CloseCombatEnemy();
    }

    protected virtual void CloseCombatEnemy()
    {
        //For override
    }

    protected abstract bool CanCloseCombat();
}
