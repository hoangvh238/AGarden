using UnityEngine;

public class BulletMovement : Movement
{
    [SerializeField] protected BulletController bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": Load BulletController", gameObject);
    }

    protected virtual void DespawnToPool()
    {
        this.bulletCtrl.BulletDespawner.DespawnObject();
    }
}

