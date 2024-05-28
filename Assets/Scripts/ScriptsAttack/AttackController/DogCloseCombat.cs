using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCloseCombat : CloseCombat
{
    protected override bool CanCloseCombat()
    {
        return true;
    }
}
