using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class ImpactEnemy : LoadEnemyController
{
    [Header("Impact Enemy")]
    [SerializeField] protected Rigidbody2D rigidComponent;
    [SerializeField] protected BoxCollider2D boxComponent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigidComponent != null) return;
        this.rigidComponent = GetComponent<Rigidbody2D>();
        this.rigidComponent.isKinematic = true;
        Debug.Log(transform.name + ": Load Rigibody2D", gameObject);
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxComponent != null) return;
        this.boxComponent = GetComponent<BoxCollider2D>();
        this.boxComponent.isTrigger = true;
        Debug.Log(transform.name + ": Load BoxCollider2D", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        this.EnemyCtrl.DameSen.Send(collision.transform);
    }
}
