using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : SpawnPoolObj
{
    public static string monkeyBullet = "MonkeyBullet";
    public static string hedgeBullet = "HedgeBullet";

    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        BulletSpawner.instance = this;
        Debug.Log(transform.name + ": Load Instance", gameObject);
    }
}
