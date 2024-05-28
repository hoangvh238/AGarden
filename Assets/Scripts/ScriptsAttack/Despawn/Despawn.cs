using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : AutoMonoBehaviour
{
    protected virtual void Update()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    {
       //For override
    }

    protected abstract bool CanDespawn();
}
