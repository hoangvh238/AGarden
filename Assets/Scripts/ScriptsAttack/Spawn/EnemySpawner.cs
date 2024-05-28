using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SpawnPoolObj
{
    public static string skeletonEnemy = "Skeleton";
    public static string ghostEnemy = "Ghost";
    public static string wolfEnemy = "Wolf";
    public static string pumpkinEnemy = "Pumpkin";
    public static string witchEnemy = "Witch";
    public static string dracularEnemy = "Dracular";
    public static string stoneEnemy = "Stone";
    public static string batEnemy = "Bat";

    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }
}
