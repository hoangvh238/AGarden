using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemyController : AutoMonoBehaviour
{
    [Header("Load Controller")]
    [SerializeField] protected EnemyController enemyCtrl;
    public EnemyController EnemyCtrl => this.enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyController", gameObject);
    }
}
