using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlacedRegion : PlacedRegion
{
    protected override bool CanChange(Transform newRegion)
    {
        return true;
    }
}
