using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dame", menuName = "ScriptableObjects/Dame")]
public class DameSO : ScriptableObject
{
    [SerializeField] protected int dame = 100;
    [SerializeField] protected int dameMax = 1000;

    public int Dame => this.dame;
    public int DameMax => this.dameMax;
}
