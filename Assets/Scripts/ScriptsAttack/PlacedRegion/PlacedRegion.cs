using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacedRegion : AutoMonoBehaviour
{
    [SerializeField] protected Transform region;

    public virtual void ChangeRegion(Transform newRegion)
    {
        if (!CanChange(newRegion)) return;
        this.region = newRegion;
    }

    public virtual void ChangeStaticRegion(bool statusRegion)
    {
        this.region.GetComponent<ObjectCell>().ChangeStatus(statusRegion);
    }

    protected abstract bool CanChange(Transform newRegion);
}
