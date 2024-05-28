using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGame : MonoBehaviour
{
    public int countButton;
    public bool isChange;
    void Awake()
    {
        countButton = 1;
    }

    // Update is called once per frame
    public void CountSpeedClick()
    {
        countButton++;
        isChange = true;
    }
    public int GetSpeedGame()
    {
        if(countButton%2==0)
            return 1;
        if (countButton % 2 != 0)
            return 0;
        return -1;
    }
}
