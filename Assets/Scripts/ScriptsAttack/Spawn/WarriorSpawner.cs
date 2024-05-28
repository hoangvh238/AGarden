using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawner : SpawnPoolObj
{
    public static string monkeyWarrior = "Monkey";
    public static string hedgeWarrior = "Hedge";
    public static string dogWarrior = "Dog";
    public static string frogWarrior = "Frog";
    public static string catWarrior = "Cat";
    public static string turtleWarrior = "Turtle";

    protected static WarriorSpawner instance;
    public static WarriorSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        WarriorSpawner.instance = this;
    }

    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);
        obj.GetComponent<WarriorController>().PlacedRegion.ChangeStaticRegion(false);
        obj.GetComponent<WarriorController>().PlacedRegion.ChangeRegion(null);
    }
}
