using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateChestManager : MonoBehaviour
{
    public WeightedRandomList<Transform> lootTable;
    //count spwan
    public int countSpawnChest;
    // cong vao ti le : xuat hien tien va warrior
    public float normalMonster =0; 
    //cong vao ti le : tinh linh tro giup
    public float hardMonster =0;
    // 4 loai ruong
    public List<GameObject> listChest = new List<GameObject>();
    // thang do random // start with 70-20-10- [0] [1] [2] [3]
   public List<int> rateSpawn = new List<int>();
    private void Update()
    {
        if(normalMonster > 10)
        {
            UpdateRateMedium();
            normalMonster -= 10;
        }
        if(countSpawnChest > 1)
        {
            SpawnChest(listChest, rateSpawn);
            countSpawnChest -= 1;  
        }
    }
    private void UpdateRateMedium()
    {
        if (rateSpawn[0] > 30 && rateSpawn[1]<65)
        {
            rateSpawn[0]--;
            rateSpawn[1]++;
        }
        else 
        {
            rateSpawn[2]++;
        }

    }
    private void UpdateRateHight()
    {

    }
    private void SpawnChest(List<GameObject> listChest, List<int> listRate)
    {
        Vector2 vector2 = Vector2.zero;
        lootTable.ClearList();
        for(int i=0; i < listChest.Count; i++)
        {
            lootTable.Add(listChest[i].transform, listRate[i]);
        }
        var placeFather = GameObject.Find("AttackScene");
        Instantiate(lootTable.GetRandom(), placeFather.transform);
    }
}
