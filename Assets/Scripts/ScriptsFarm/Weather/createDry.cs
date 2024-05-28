using UnityEngine;

public class createDry : MonoBehaviour
{
    public int numberDry = 0;
    private double timeNext;
    private double rateTime = 2f;

    private GameObject seed;
    int createKeyRandom()
    {
        while (true)
        {
            if (manageTitleFarm.manageTiFarm.numberSeed <= numberDry) return -1;
            int keyTi = Random.Range(0, manageTitleFarm.staticTitles.Count);

            seed = manageTitleFarm.manageTiFarm.findTitle(keyTi, 0);

            if (seed.GetComponent<Seed>().haveDry == false)
            {
                seed.GetComponent<Seed>().haveDry = true;
                return keyTi;
            }
        }
    }
    private void Update()
    {
        if (TimeController.Instance.DayPresent == 3)
        {
            if (Time.time < timeNext) return;
            timeNext = Time.time + rateTime;

            int Key = createKeyRandom();
            if (Key != -1) numberDry = numberDry + 1;
        }
    }
}
