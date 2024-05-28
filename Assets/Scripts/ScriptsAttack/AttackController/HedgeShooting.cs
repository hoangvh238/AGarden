using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeShooting : Shooting
{
    protected override void Shoot()
    {
        base.Shoot();
        Vector3 pos = this.pointSpawn.transform.position;
        Quaternion rot = transform.rotation;

        var bullet = BulletSpawner.Instance.Spawn(BulletSpawner.hedgeBullet, pos, rot);
        bullet.gameObject.SetActive(true);
        bullet.transform.parent.Find("Movement").GetComponent<HedgeBulletMovement>().ChangeTarget(this.scannerObject.EnemyFound);
    }

    protected override bool CanShooting()
    {
        if (Time.time < this.timeSpawnNext) return false;
        this.timeSpawnNext = Time.time + this.rateTimeShooting;
        return true;
    }
}
