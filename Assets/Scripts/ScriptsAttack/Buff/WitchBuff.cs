using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBuff : Buff
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIndex();
    }

    protected virtual void LoadIndex()
    {
        this.dameBuff = 2;
        this.healthBuff = 2;
        this.speedBuff = 0.01f;
    }

    protected override void AddDame(Transform obj)
    {
        base.AddDame(obj);
        EnemyDamagedSender key = obj.transform.parent.GetComponent<EnemyDamagedSender>();
        if (key == null) return;
        this.AddDame(key);
    }

    protected override void AddSpeed(Transform obj)
    {
        base.AddSpeed(obj);
        EnemyMovement key = obj.transform.parent.GetComponent<EnemyMovement>();
        if (key == null) return;
        this.AddSpeed(key);
    }

    protected override void AddHealth(Transform obj)
    {
        base.AddHealth(obj);
        EnemyDamagedReceiver key = obj.transform.parent.GetComponent<EnemyDamagedReceiver>();
        if (key == null) return;
        this.AddHealth(key);
    }

    protected virtual void AddHealth(EnemyDamagedReceiver obj)
    {
        obj.Add(this.healthBuff);
    }

    protected virtual void AddSpeed(EnemyMovement obj)
    {
        obj.Add(this.speedBuff);
    }

    protected virtual void AddDame(EnemyDamagedSender obj)
    {
        obj.Add(this.dameBuff);
    }
}
