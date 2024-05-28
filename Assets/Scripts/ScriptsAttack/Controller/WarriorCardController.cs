using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCardController : AutoMonoBehaviour
{
    [SerializeField] protected WarriorBuyAndSell buyAndSell;

    public WarriorBuyAndSell BuyAndSell => this.buyAndSell;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuyAndSell();
    }

    protected virtual void LoadBuyAndSell()
    {
        if (this.buyAndSell != null) return;
        this.buyAndSell = transform.Find("BuyAndSell").GetComponent<WarriorBuyAndSell>();
        Debug.Log(transform.name + ": Load BuyAndSell", gameObject);
    }
}
