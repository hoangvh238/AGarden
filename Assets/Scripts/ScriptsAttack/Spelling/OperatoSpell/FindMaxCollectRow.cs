using System.Collections.Generic;
using UnityEngine;


// tam thoi k dung 
public class FindMaxCollectRow : MonoBehaviour
{
    public FindPlaceDrop findPlaceDrop;
    public List<GameObject> row1;
    public List<GameObject> row2;
    public List<GameObject> row3;
    public List<GameObject> row4;
    public List<GameObject> row5;

    //public List<List<GameObject>> row;
    public int numberCollectRow;
    public int test;
    public void UpdateRowList()
    {
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        int k = 0;
        foreach (Transform t in spawner.transform)
        {
            switch (k)
            {
                case 0:
                    row1 = t.GetComponent<SpawnPoint>().monsters;
                    break;
                case 1:
                    row2 = t.GetComponent<SpawnPoint>().monsters;
                    break;
                case 2:
                    row3 = t.GetComponent<SpawnPoint>().monsters;
                    break;
                case 3:
                    row4 = t.GetComponent<SpawnPoint>().monsters;
                    break;
                case 4:
                    row5 = t.GetComponent<SpawnPoint>().monsters;
                    break;
            }
            k++;
        }
    }
    public int FindRightList()
    {
        UpdateRowList();
        //
        int[] index = new int[7];
        int numberZerolist = -2;
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 0:
                    index[i] = 0;
                    break;
                case 1:
                    index[i] = row1.Count > 0 ? 1 : 0;
                    break;
                case 2:
                    index[i] = row2.Count > 0 ? 1 : 0;
                    break;
                case 3:
                    index[i] = row3.Count > 0 ? 1 : 0;
                    break;
                case 4:
                    index[i] = row4.Count > 0 ? 1 : 0;
                    break;
                case 5:
                    index[i] = row5.Count > 0 ? 1 : 0;
                    break;
                case 6:
                    index[i] = 0;
                    break;
            }
            if (index[i] == 0) numberZerolist++;
        }

        //
        int check = 0;
        if (numberZerolist == 5)
        {
            return 0;
        }
        else
        if (numberZerolist == 4)
        {
            numberCollectRow = 1;
            int max = row1.Count > row2.Count ? row1.Count : row2.Count;
            int max2 = row3.Count > row4.Count ? row3.Count : row4.Count;
            max = max > max2 ? max : max2;
            max = max > row5.Count ? max : row5.Count;
            if (max == row1.Count) return 1;
            if (max == row2.Count) return 2;
            if (max == row3.Count) return 3;
            if (max == row4.Count) return 4;
            if (max == row5.Count) return 5;
        }
        else
            for (int i = 1; i < 6; i++)
            {
                if (index[i] > 0)
                {
                    check = index[i - 1] + index[i + 1];
                    if (check < index[i])
                    {
                        index[i] = 0;
                        numberZerolist++;
                    }
                }
            }
        int maxTotal = 0;
        //
        if (numberZerolist == 5)
        {
            numberCollectRow = 1;
            int max = row1.Count > row2.Count ? row1.Count : row2.Count;
            int max2 = row3.Count > row4.Count ? row3.Count : row4.Count;
            max = max > max2 ? max : max2;
            max = max > row5.Count ? max : row5.Count;
            if (max == row1.Count) return 1;
            if (max == row2.Count) return 2;
            if (max == row3.Count) return 3;
            if (max == row4.Count) return 4;
            if (max == row5.Count) return 5;
        }


        //
        int sumMax = 0;
        for (int i = 1; i < 5; i++)
        {
            if (index[i] == 1)
            {
                if (index[i + 1] == 1)
                {
                    if (index[i + 2] == 1)
                    {
                      
                        int newValue = GetTotalMonster(i, i + 1, i + 2);
                        if (newValue > maxTotal)
                        {
                            maxTotal = newValue;
                            sumMax = 3*i + 3;
                            numberCollectRow = 3;
                        }
                        i++;
                    }
                    else
                    {
                        int newValue = GetTotalMonster(i, i + 1);
                        if (newValue > maxTotal)
                        {
                            maxTotal = newValue;
                            sumMax = 2 * i + 1;
                            numberCollectRow = 2;
                        }
                        i += 2;
                    }

                }
            }
        }
        test = sumMax;
        return sumMax;
    }

    public int GetTotalMonster(int a, int b)
    {
        int fist = 0, second = 0;
        switch (a)
        {
            case 1:
                fist = row1.Count;
                break;
            case 2:
                fist = row2.Count;
                break;
            case 3:
                fist = row3.Count;
                break;
            case 4:
                fist = row4.Count;
                break;
            case 5:
                fist = row5.Count;
                break;
        }
        switch (b)
        {
            case 1:
                second = row1.Count;
                break;
            case 2:
                second = row2.Count;
                break;
            case 3:
                second = row3.Count;
                break;
            case 4:
                second = row4.Count;
                break;
            case 5:
                second = row5.Count;
                break;
        }

        return fist + second;
    }
    public int GetTotalMonster(int a, int b, int c)
    {
        int fist = 0, second = 0, third = 0;
        switch (a)
        {
            case 1:
                fist = row1.Count;
                break;
            case 2:
                fist = row2.Count;
                break;
            case 3:
                fist = row3.Count;
                break;
            case 4:
                fist = row4.Count;
                break;
            case 5:
                fist = row5.Count;
                break;
        }
        switch (b)
        {
            case 1:
                second = row1.Count;
                break;
            case 2:
                second = row2.Count;
                break;
            case 3:
                second = row3.Count;
                break;
            case 4:
                second = row4.Count;
                break;
            case 5:
                second = row5.Count;
                break;
        }
        switch (c)
        {
            case 1:
                third = row1.Count;
                break;
            case 2:
                third = row2.Count;
                break;
            case 3:
                third = row3.Count;
                break;
            case 4:
                third = row4.Count;
                break;
            case 5:
                third = row5.Count;
                break;
        }
        return fist + second + third;
    }

    public void FindPlaceDrop()
    {
        findPlaceDrop = GameObject.Find("FindPlaceDrop").transform.GetComponent<FindPlaceDrop>();
        switch (FindRightList())
        {
            case 0:
                //
                break;
            case 1:
                findPlaceDrop.areaFindDrop(row1);
              
                break;
            case 2:
                findPlaceDrop.areaFindDrop(row2);
                
                break;
            case 3:
                if (numberCollectRow == 1) findPlaceDrop.areaFindDrop(row3);
                else
                {
                    findPlaceDrop.areaFindDrop(row1,row2);
                }
              
                break;
            case 4:
                findPlaceDrop.areaFindDrop(row4);
             
                break;
            case 5:
                if (numberCollectRow == 1) findPlaceDrop.areaFindDrop(row5);
                else
                {
                    findPlaceDrop.areaFindDrop(row2,row3);
                }
               
                break;
            case 6:
                findPlaceDrop.areaFindDrop(row1,row2,row3);
               
                break;
            case 7:

                findPlaceDrop.areaFindDrop(row3,row4);
       
                break;
            case 9:
                if (numberCollectRow == 2)
                {
                    findPlaceDrop.areaFindDrop(row4,row5);
                }
                else
                {
                    findPlaceDrop.areaFindDrop(row2,row3,row4);
                }
             
                break;
            case 12:
                findPlaceDrop.areaFindDrop(row3,row4,row5);
       
                break;
        }
    }
   
}
