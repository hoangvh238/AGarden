using UnityEngine;

public class GhostEnemyDamagedSender : EnemyDamagedSender
{
    protected override void SendDame(WarriorDamagedReceiver warrior)
    {
        base.SendDame(warrior);
        this.SpawnStone(warrior.transform);
        WarriorSpawner.Instance.Despawn(warrior.transform.parent);
    }

    protected virtual void SpawnStone(Transform obj)
    {
        var stone = EnemySpawner.Instance.Spawn(EnemySpawner.stoneEnemy, obj.position, obj.rotation);
        stone.gameObject.SetActive(true);
    }

    protected override void DestroyObject()
    {
        base.DestroyObject();
        EnemySpawner.Instance.Despawn(gameObject.transform.parent);
    }
}
