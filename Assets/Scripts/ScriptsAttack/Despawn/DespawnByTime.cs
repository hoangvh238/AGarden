using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timeDespawn = 2f;
    [SerializeField] protected float timeStartSpawn;

    protected override void Awake()
    {
        base.Update();
        Invoke("DespawnObject", 2f);
    }

    public override void DespawnObject()
    {
        base.DespawnObject();
    }
    
    protected override bool CanDespawn()
    {
        if (Time.time < this.timeStartSpawn + this.timeDespawn) return false;
        return true;
    }
}
