using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorShadowSetActive : SetActive
{
    [SerializeField] protected static WarriorShadowSetActive instance;

    public static WarriorShadowSetActive Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        WarriorShadowSetActive.instance = this;
    }
}
