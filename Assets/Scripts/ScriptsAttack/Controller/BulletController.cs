using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : AutoMonoBehaviour
{
    protected BulletController bulletContrl;
    [SerializeField] protected WarriorDamagedSender dameSen;
    [SerializeField] protected ImpactBullet impactBullet;
    [SerializeField] protected BulletDespawn bulletDespawner;
    [SerializeField] protected BulletMovement bulletMovement;
    [SerializeField] protected DameSO dameSO;

    public BulletController BulletContrl => this.bulletContrl;
    public WarriorDamagedSender DameSen => this.dameSen;
    public ImpactBullet ImpactBullet => this.impactBullet;
    public BulletDespawn BulletDespawner => this.bulletDespawner;
    public BulletMovement BulletMovement => this.bulletMovement;
    public DameSO DameSO => this.dameSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
      /*  this.LoadBulletController();*/
        this.LoadDamagedSender();
        this.LoadImpactBullet();
        this.LoadBulletDespawner();
        this.LoadMovement();
        this.LoadDameSO();
    }

    protected virtual void LoadDameSO()
    {
        if (this.dameSO != null) return;
        string resPath = "Dame/" + "Dame" + transform.name;
        this.dameSO = Resources.Load<DameSO>(resPath);
        Debug.LogWarning(transform.name + ": Load DameSO" + resPath, gameObject);
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletContrl != null) return;
        this.bulletContrl = GetComponent<BulletController>();
        Debug.Log(transform.name + ": Load BulletController", gameObject);
    }

    protected virtual void LoadImpactBullet()
    {
        if (this.impactBullet != null) return;
        this.impactBullet = transform.Find("ImpactBullet").GetComponent<ImpactBullet>();
        Debug.Log(transform.name + ": Load Impact Bullet", gameObject);
    }

    protected virtual void LoadDamagedSender()
    {
        if (this.dameSen != null) return;
        this.dameSen = transform.Find("DamagedSender").GetComponent<WarriorDamagedSender>();
        Debug.Log(transform.name + ": Load DamagedSender", gameObject);
    }

    protected virtual void LoadBulletDespawner()
    {
        if (this.bulletDespawner != null) return;
        this.bulletDespawner = transform.Find("Despawn").GetComponent<BulletDespawn>();
        Debug.Log(transform.name + ": Load Despawn", gameObject);
    }

    protected virtual void LoadMovement()
    {
        //For override
    }
}
