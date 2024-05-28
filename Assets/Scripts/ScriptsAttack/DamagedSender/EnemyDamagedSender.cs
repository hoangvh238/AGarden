using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedSender : DamagedSender
{
    [SerializeField] protected EnemyController enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
        this.LoadDame();
    }

    protected virtual void LoadDame()
    {
        this.maxDame = this.enemyCtrl.DameSO.DameMax;
        this.dame = this.enemyCtrl.DameSO.Dame;
    }

    protected virtual void LoadEnemyController()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyController", gameObject);
    }

    public override void Send(Transform obj)
    {
        WarriorDamagedReceiver dameToObj = obj.GetComponentInChildren<WarriorDamagedReceiver>();
        if (dameToObj == null) return;
        this.SendDame(dameToObj);
    }

    protected virtual void SendDame(WarriorDamagedReceiver warrior)
    {
        warrior.Deduct(this.dame);
        this.DestroyObject();
    }
}
