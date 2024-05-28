using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : AutoMonoBehaviour
{
    [SerializeField] protected int dameBuff = 2;
    [SerializeField] protected int healthBuff = 2;
    [SerializeField] protected float speedBuff = 2;

    [SerializeField] protected bool isBuff = false;

    protected virtual bool CanBuff()
    {
        if (isBuff) return false;
        return true;
    }

    protected virtual void AddHealth(Transform obj)
    {
        if (!CanBuff()) return;
        // For override
    }

    protected virtual void AddSpeed(Transform obj)
    {
        if (!CanBuff()) return;
        //For override
    }

    protected virtual void AddDame(Transform obj)
    {
        if (!CanBuff()) return;
        //For override
    }

}
