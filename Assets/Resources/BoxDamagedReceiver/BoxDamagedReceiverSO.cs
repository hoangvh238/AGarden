using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxDamagedReceiver", menuName = "ScriptableObjects/BoxDamagedReceiver")]

public class BoxDamagedReceiverSO : ScriptableObject
{
    [SerializeField] protected float offSetX = 0;
    [SerializeField] protected float offSetY = 0;
    [SerializeField] protected float sizeX = 1;
    [SerializeField] protected float sizeY = 1;

    public float OffSetX => this.offSetX;
    public float OffSetY => this.offSetY;
    public float SizeX => this.sizeX;
    public float SizeY => this.sizeY;

}
