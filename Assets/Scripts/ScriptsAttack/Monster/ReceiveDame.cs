using System;
using UnityEngine;

public class ReceiveDame : LoadEnemyController
{
    public int health;
    public bool isStopped;
    public bool isEffect;
    public bool isGround;

    public GameObject buffWitch;

    public float upRate = 2;
    public GameObject managerChest;

    protected override void Start()
    {
       /* if(this.gameObject.name == "Witch(Clone)")
        isGround = false;
        else
        isGround = true;
*/
        managerChest = GameObject.Find("ManagerRateChest");
        upRate = 2;
    }
    public void Damaged(int dame, Vector2 pos)
    {
       
         /*   if(this.gameObject.name != "Dracular(Clone)" || this.gameObject.name != "Ghost(Clone)" || this.gameObject.name != "Bat")
            {
                managerChest.GetComponent<RateChestManager>().normalMonster += upRate;
                managerChest.GetComponent<RateChestManager>().countSpawnChest ++;
            }
            else
            {
                  managerChest.GetComponent<RateChestManager>().hardMonster += upRate;
                  managerChest.GetComponent<RateChestManager>().countSpawnChest++;
            }*/
    }
  /* public bool getGround()
    {
        return isGround;
    }    
    public void setGround(bool ground)
    {
        this.isGround = ground;
    }*/
    public void getWitchBuff()
    {
        var buffWitchClone = Instantiate(buffWitch,this.gameObject.transform);
        Destroy(buffWitchClone, 1f);
    }


}
