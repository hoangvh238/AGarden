using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : AutoMonoBehaviour
{
    [SerializeField] protected int moneyPresent = 1000;
    [SerializeField] protected int monneyMax = 99999;
    [SerializeField] protected static MoneyController instance;

    public static MoneyController Instance => instance;
    public int MoneyPresent => this.moneyPresent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        MoneyController.instance = this;
    }

    public virtual void AddMoney(int money)
    {
        if (!CanUseMoney()) return;
        this.moneyPresent = Mathf.Min(this.monneyMax, this.moneyPresent + money);
    }

    public virtual void DeductMoney(int money)
    {
        if (!CanUseMoney()) return;
        this.moneyPresent = Mathf.Max(0, this.moneyPresent - money);
    }

    protected virtual bool CanUseMoney()
    {
        //For override
        return true;
    }
}
