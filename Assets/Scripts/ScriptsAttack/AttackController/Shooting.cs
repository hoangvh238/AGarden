using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooting : Attack
{
    [SerializeField] protected float rateTimeShooting = 1f;
    [SerializeField] protected Transform pointSpawn;
    protected float timeSpawnNext;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPointSpawn();
    }

    protected virtual void LoadPointSpawn()
    {
        if (this.pointSpawn != null) return;
        this.pointSpawn = gameObject.transform.Find("PointSpawn").transform;
        Debug.Log(transform.name + ": Load PointSpawn", gameObject);
    }

    protected override bool CheckAttack()
    {
        if (!this.CanShooting()) return false;
        return base.CheckAttack();
    }

    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        this.Shoot();
    }

    protected virtual void Shoot()
    {
        //For override
    }

    protected abstract bool CanShooting();
}
