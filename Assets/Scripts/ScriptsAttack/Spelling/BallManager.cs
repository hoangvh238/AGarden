using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

     private static BallManager Instance;
     FindMaxCollectRow findMaxCollect;
     FindPlaceDrop findPlace;
     
    public static BallManager InstanceSpell { get => Instance; }
    public FindMaxCollectRow FindMaxCollect { get => findMaxCollect; }
    public FindPlaceDrop FindPlace => findPlace; 
    // managerWeather managerWeather;
    private void Awake()
    {
        Instance = this;
        findMaxCollect = GameObject.Find("FindMaxCollectRow").transform.GetComponent<FindMaxCollectRow>();
    }
}
