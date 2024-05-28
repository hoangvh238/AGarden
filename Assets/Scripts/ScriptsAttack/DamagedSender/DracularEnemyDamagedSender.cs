using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracularEnemyDamagedSender : EnemyDamagedSender
{
    [SerializeField] protected int bloodSucking = 2;

    protected override void SendDame(WarriorDamagedReceiver warrior)
    {
        base.SendDame(warrior);
        this.enemyCtrl.DameRec.Add(this.bloodSucking);
    }

}
