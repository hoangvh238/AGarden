using UnityEngine;

public class MonkeyShooting : Shooting
{
    protected override void Shoot()
    {
        base.Shoot();

        Vector3 pos = this.pointSpawn.transform.position;
        Quaternion rot = transform.rotation;

        var bullet = BulletSpawner.Instance.Spawn(BulletSpawner.monkeyBullet, pos, rot);  
        bullet.gameObject.SetActive(true);
    }

    protected override bool CanShooting()
    {
        if (Time.time < this.timeSpawnNext) return false;
        this.timeSpawnNext = Time.time + this.rateTimeShooting;
        return true;
    }
}
