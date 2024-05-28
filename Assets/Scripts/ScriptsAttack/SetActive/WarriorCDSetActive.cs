using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCDSetActive : SetActive
{
    [SerializeField] protected static WarriorCDSetActive instance;

    public static WarriorCDSetActive Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        WarriorCDSetActive.instance = this;
    }
}
