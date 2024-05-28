using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuyAndSell : AutoMonoBehaviour
{
    [SerializeField] protected int costBuy = 100;
    [SerializeField] protected int costSell = 10;

    [SerializeField] protected float rateTimeBuy = 5f; 
    [SerializeField] protected float timePreBuy;

    public int CostBuy => this.costBuy;

    public int CostSell => this.CostSell;
    public float RateTimeBuy => this.rateTimeBuy;

    public virtual bool RequestBuy(int costPresent)
    {
        if (!CanBuy(costPresent)) return false;
        this.timePreBuy = Time.time;
        return true;
    }

    protected virtual bool CanBuy(int costPresent)
    {
        if (costPresent < this.costBuy) return false;
        if (this.timePreBuy + this.rateTimeBuy > Time.time) return false;
        return true;
    }

    public virtual bool RequestSell(int costPresent)
    {
        if (!CanSell(costPresent)) return false;
        return false;
    }

    protected abstract bool CanSell(int costPresent);
}
