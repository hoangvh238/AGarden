using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField] protected bool isDespawn = false;
    public override void DespawnObject()
    {
        base.DespawnObject();
        BulletSpawner.Instance.Despawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        base.CanDespawn();
        if (isDespawn) return true;
        else return false;
    }
}
