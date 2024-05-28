using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : AutoMonoBehaviour
{
    [SerializeField] protected string nameEnemy;
    [SerializeField] protected int numberAppear = 10;

    public int NumberForCreate;

    public int NumberAppear => this.numberAppear;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNameEnemy();
        this.NumberForCreate = this.numberAppear;
    }

    public virtual void DeductNumber(int number)
    {
        this.NumberForCreate = Mathf.Max(0, this.NumberForCreate - number);
    }

    protected virtual string GetName(string nameParent)
    {
        return nameParent.Remove(nameParent.Length - 5, 5);
    }

    protected virtual void LoadNameEnemy()
    {
        this.nameEnemy = this.GetName(transform.name);
        Debug.Log(transform.name + ": Load nameEnemy", gameObject);
    }
}
