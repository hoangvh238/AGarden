using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDamagedReceiver : DamagedReceiver
{
    [SerializeField] protected WarriorController warriorCtrl;

    protected override void LoadComponents()
    {
        this.LoadWarriorController();
        base.LoadComponents();
        this.LoadBoxCollider();
        this.LoadHealth();
    }

    protected override void LoadBoxCollider()
    {
        base.LoadBoxCollider();
        this.boxComponent.offset = new Vector2(this.warriorCtrl.BoxDamagedReceiverSO.OffSetX, this.warriorCtrl.BoxDamagedReceiverSO.OffSetY);
        this.boxComponent.size = new Vector2(this.warriorCtrl.BoxDamagedReceiverSO.SizeX, this.warriorCtrl.BoxDamagedReceiverSO.SizeY);
    }

    protected virtual void LoadHealth()
    {
        this.healthMax = this.warriorCtrl.HealthSO.HealhMax;
        this.Reborn();
    }

    protected virtual void LoadWarriorController()
    {
        if (this.warriorCtrl != null) return;
        this.warriorCtrl = transform.parent.GetComponent<WarriorController>();
        Debug.Log(transform.name + ": Load WarriorCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        WarriorSpawner.Instance.Despawn(transform.parent);
       /* this.enemyCtrl.PointSpawn.monsters.Remove(this.enemyCtrl.gameObject);*/
    }
}
