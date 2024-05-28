using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedReceiver : DamagedReceiver
{
    [SerializeField] protected EnemyController enemyCtrl;
    [SerializeField] protected bool isProtected = false;

    protected override void LoadComponents()
    {
        this.LoadEnemyController();
        base.LoadComponents();
    }

    protected override void LoadBoxCollider()
    {
        base.LoadBoxCollider();
        this.boxComponent.offset = new Vector2(this.enemyCtrl.BoxDamagedReceiverSO.OffSetX, this.enemyCtrl.BoxDamagedReceiverSO.OffSetY);
        this.boxComponent.size = new Vector2(this.enemyCtrl.BoxDamagedReceiverSO.SizeX, this.enemyCtrl.BoxDamagedReceiverSO.SizeY);
    }

    protected virtual void LoadEnemyController()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyCtrl", gameObject);
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        if (!this.CheckHealthToProtect()) return;
        this.ProtectedSkill();
    }

    protected override void OnDead()
    {
        base.OnDead();
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected virtual bool CheckHealthToProtect()
    {
        return false;
    }

    protected virtual void ProtectedSkill()
    {
        
    }
}
