using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] protected EnemyController enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
        this.LoadSpeed();
    }

    protected virtual void LoadEnemyController()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyController", gameObject);
    }

    protected virtual void LoadSpeed()
    {
        this.speedMax = this.enemyCtrl.SpeedSO.SpeedMax;
        this.speedObject = this.enemyCtrl.SpeedSO.SpeedObject;
    }

    protected override void Move()
    {
        base.Move();
        transform.parent.Translate(new Vector3(this.direction * speedObject, 0, 0));
    }
}
