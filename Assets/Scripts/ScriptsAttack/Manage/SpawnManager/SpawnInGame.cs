using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInGame : AutoMonoBehaviour
{
    [SerializeField] protected float spawnNext;
    [SerializeField] protected int countSpawn;

    protected virtual void Update()
    {
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        if (Time.time < this.spawnNext) return;
        this.countSpawn = this.countSpawn + 1;

        ListSpawner key = ControllerSpawner.Instance.DayPresent.GetComponentInChildren<ListSpawner>();
        float getRateAndSpawn = key.RequestSpawn(this.countSpawn - 1);
        this.spawnNext = this.spawnNext + getRateAndSpawn;
    }
}
