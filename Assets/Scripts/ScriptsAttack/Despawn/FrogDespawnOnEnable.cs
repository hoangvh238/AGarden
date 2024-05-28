using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDespawnOnEnable : DespawnOnEnable
{
    public override void DespawnObject()
    {
        base.DespawnObject();
        WarriorSpawner.Instance.Despawn(transform.parent);
    }
}
