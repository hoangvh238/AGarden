using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "ScriptableObjects/Health")]
public class HealthSO : ScriptableObject
{
    [SerializeField] protected int health = 800;
    [SerializeField] protected int healthMax = 800;

    public int Health => this.health;
    public int HealhMax => this.healthMax;
}
