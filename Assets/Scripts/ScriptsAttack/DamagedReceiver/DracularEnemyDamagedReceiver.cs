using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracularEnemyDamagedReceiver : EnemyDamagedReceiver
{
    protected override void OnDead()
    {
        var bat = EnemySpawner.Instance.Spawn(EnemySpawner.batEnemy, transform.position, transform.rotation);
        bat.gameObject.SetActive(true);
        base.OnDead();
    }
}
