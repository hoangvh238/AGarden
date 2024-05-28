using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBulletDamagedSender : WarriorDamagedSender
{
    [SerializeField] protected BulletController bulletCtrl;

    protected override void LoadComponents()
    {
        this.LoadBulletController();
        base.LoadComponents();
        this.LoadDame();
    }

    protected override void LoadDame()
    {
        this.dame = this.bulletCtrl.DameSO.Dame;
        this.maxDame = this.bulletCtrl.DameSO.DameMax;
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": Load Bullet Controller", gameObject);
    }

    protected override void DestroyObject()
    {
        base.DestroyObject();
    }
}
