using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWarriorController : AutoMonoBehaviour
{
    [Header("Load Controller")]
    [SerializeField] protected WarriorController warriorCtrl;
    public WarriorController WarriorCtrl => this.warriorCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWarriorCtrl();
    }

    protected virtual void LoadWarriorCtrl()
    {
        if (this.warriorCtrl != null) return;
        this.warriorCtrl = transform.parent.parent.GetComponent<WarriorController>();
        Debug.Log(transform.name + ": Load WarriorController", gameObject);
    }
}
