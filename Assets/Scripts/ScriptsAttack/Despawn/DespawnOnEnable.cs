using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnEnable : Despawn
{
    protected override bool CanDespawn()
    {
        return true;
    }

    protected virtual void OnEnable()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }
}
