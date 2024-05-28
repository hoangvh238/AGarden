using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseCombat : CloseCombat
{
    [SerializeField] protected Transform movement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMovement();
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.Find("Movement");
        Debug.Log(transform.name + ": Load Movement", gameObject);
    }

    protected override void CloseCombatEnemy()
    {
        base.CloseCombatEnemy();
        this.movement.gameObject.SetActive(false);
    }

    protected override void NotAttackEnemy()
    {
        base.NotAttackEnemy();
        this.movement.gameObject.SetActive(true);
    }

    protected override bool CanCloseCombat()
    {
        return true;
    }
}
