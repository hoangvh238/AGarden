using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ImpactBullet : LoadBulletController
{
    [SerializeField] protected Rigidbody2D rigidComponent;
    [SerializeField] protected BoxCollider2D boxComponent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody2D();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadRigibody2D()
    {
        if (this.rigidComponent != null) return;
        this.rigidComponent = gameObject.GetComponent<Rigidbody2D>();
        this.rigidComponent.isKinematic = true;
        Debug.Log(transform.name + ": Load Rigibody2D", gameObject);
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxComponent != null) return;
        this.boxComponent = gameObject.GetComponent<BoxCollider2D>();
        this.boxComponent.isTrigger = true;
        Debug.Log(transform.name + ": Load BoxCollider", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        this.bulletCtrl.DameSen.Send(collision.transform);
    }
}
