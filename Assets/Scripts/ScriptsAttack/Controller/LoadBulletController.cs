using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBulletController : AutoMonoBehaviour
{
    [Header("Load Controller")]
    [SerializeField] protected BulletController bulletCtrl;
    public BulletController EnemyCtrl => this.bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": Load BulletController", gameObject);
    }
}
