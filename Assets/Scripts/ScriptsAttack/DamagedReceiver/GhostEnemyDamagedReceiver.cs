using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyDamagedReceiver : EnemyDamagedReceiver
{
    [SerializeField] protected int timeProtect = 3;

    protected override void ProtectedSkill()
    {
        base.ProtectedSkill();
        this.ProtectEnemy();
        Invoke("DisableProtectEnemy", this.timeProtect);
    }

    protected virtual void ProtectEnemy()
    {
        this.isProtected = true;
        this.enemyCtrl.DameRec.gameObject.SetActive(false);
        this.enemyCtrl.Model.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    protected virtual void DisableProtectEnemy()
    {
        this.enemyCtrl.DameRec.gameObject.SetActive(true);
        this.enemyCtrl.Model.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.57f);
    }

    protected override bool CheckHealthToProtect()
    {
        if (this.isProtected) return false;
        if (this.health / this.healthMax <= 1 / 3) return true;
        return false;
    }
}
