using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scanner", menuName = "ScriptableObjects/Scanner")]
public class ScannerSO : ScriptableObject
{
    [SerializeField] protected float distanceScanner = 9;
    [SerializeField] protected float speedScanner = 1;
    [SerializeField] protected bool rightDirection = true;

    public float DistanceScanner => this.distanceScanner;
    public float SpeedScanner => this.speedScanner;

    public bool RightDirection => this.rightDirection;
}
