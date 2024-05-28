using UnityEngine;

public class createPond : MonoBehaviour
{
    public int numberPond = 0;
    private double timeNext;
    private double rateTime = 2f;
    int createKeyRandom()
    {
        while (true)
        {
            if (manageTitleFarm.manageTiFarm.numberTitle <= numberPond) return -1;

            int keyTi = Random.Range(0, manageTitleFarm.manageTiFarm.listTitle.Length);
            GameObject tile = manageTitleFarm.manageTiFarm.listTitle[keyTi];

            if (tile.GetComponent<TitleFarm>().isFull == false)
            {
                tile.GetComponent<TitleFarm>().havePond = true;
                return keyTi;
            }
        }
    }
    private void Update()
    {
        if (TimeController.Instance.DayPresent < 4) return;
        if (Time.time < timeNext) return;
        timeNext = Time.time + rateTime;

        int Key = createKeyRandom();
        if (Key != -1) numberPond = numberPond + 1;
    }
}
