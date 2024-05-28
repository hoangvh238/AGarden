using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBuff : Buff
{
    public float timeExit;
    public int cateBuff;
    private void Start()
    {
        this.GetComponentInParent<DameToWarrior>().getBuff(cateBuff, true);
    }
    private void OnDestroy()
    {
        this.GetComponentInParent<DameToWarrior>().getBuff(cateBuff,false);
        this.GetComponentInParent<ControllListBuff>().listCatBuff.Clear();   
    }
    private void Update()
    {
        timeExit -= 1/60f;
        if (timeExit <= 0) Destroy(this.gameObject);
    }

}
