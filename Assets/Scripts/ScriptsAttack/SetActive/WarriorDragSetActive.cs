using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDragSetActive : SetActive
{
    [SerializeField] protected static WarriorDragSetActive instance;

    public static WarriorDragSetActive Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        WarriorDragSetActive.instance = this;
    }
}
