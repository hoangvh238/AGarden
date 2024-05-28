using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "ScriptableObjects/Speed")]
public class SpeedSO : ScriptableObject
{
    [SerializeField] protected float speedObject = 0.5f;
    [SerializeField] protected float speedMax = 1f;
    [SerializeField] protected bool rightDirection = false;

    public float SpeedObject => this.speedObject;
    public float SpeedMax => this.speedMax;
    public bool RightDirection => this.rightDirection;
}
