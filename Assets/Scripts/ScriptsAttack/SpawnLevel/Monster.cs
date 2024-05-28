using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster
{
    public MonsterList monsterList;
}
public enum MonsterList
{ 
    //day
    skeleton,  //0
    pumpkin,  //1
    witch, //2
    //night
    wolf, //3
    ghost, //4
    Dracular, //5
}


