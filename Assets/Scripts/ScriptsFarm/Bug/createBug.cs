using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBug : MonoBehaviour
{
    [SerializeField] float ratetime = 10f, timeNext;
    public GameObject seed;

    public GameObject[] bugs;
    public static int numberBug;

    void Update()
    {
        int day = TimeController.Instance.DayPresent;
        if (day == 2 || day == 3)
        {
            if (day == 2) ratetime = 10f;
            else ratetime = 5f;
            createBugAttack();
        }   
    }
    int createKeyRandom()
    {
        while(true)
        {
            if (manageTitleFarm.manageTiFarm.numberSeed <= numberBug) return -1;
            int keyTi = Random.Range(0, manageTitleFarm.staticTitles.Count);
     
            seed = manageTitleFarm.manageTiFarm.findTitle(keyTi, 0);

            if (seed.GetComponent<Seed>().haveBug == false)
            {
                seed.GetComponent<Seed>().haveBug = true;
                return keyTi;
            }
        }
    }
    void createBugAttack()
    {
        if (manageTitleFarm.staticTitles.Count == 0) return;
        if (Time.time < timeNext) return;
        timeNext = Time.time + ratetime;

        int key = createKeyRandom();
        if (key == -1) return;

        numberBug = numberBug + 1;
        int numBug = Random.Range(0, bugs.Length); 
        var bug = Instantiate(bugs[numBug], manageTitleFarm.manageTiFarm.findTitle(key, 1).transform);
        bug.GetComponent<Bug>().bugSeed = seed;
    }
}
