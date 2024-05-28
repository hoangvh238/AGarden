using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDamagedSender : DamagedSender
{
    [SerializeField] protected WarriorController warriorCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWarriorCtrl();
        this.LoadDame();
    }

    protected virtual void LoadWarriorCtrl()
    {
        if (this.warriorCtrl != null) return;
        this.warriorCtrl = transform.parent.GetComponent<WarriorController>();
        Debug.Log(transform.name + ": Load WarriorController", gameObject);
    }

    protected virtual void LoadDame()
    {
        this.dame = this.warriorCtrl.DameSO.Dame;
        this.maxDame = this.warriorCtrl.DameSO.DameMax;
    }

    public override void Send(Transform obj)
    {
        EnemyDamagedReceiver dameToObj = obj.GetComponent<EnemyDamagedReceiver>();
        if (dameToObj == null) return;
        this.SendDameEnemy(dameToObj);
    }

    protected virtual void SendDameEnemy(EnemyDamagedReceiver enemy)
    {
        enemy.Deduct(this.dame);
        this.DestroyObject();
    }
}
