using System.Collections.Generic;
using UnityEngine;

public class manageTitleFarm : MonoBehaviour
{
    public int numberPond;
    public int numberSeed, numberTitle;
    public static manageTitleFarm manageTiFarm;
    public static Dictionary<GameObject, GameObject> staticTitles;

    public GameObject[] listTitle;
    void Awake()
    {
        staticTitles = new Dictionary<GameObject, GameObject>();
        manageTiFarm = this;
    }
    private void Update()
    {
        numberTitle = listTitle.Length - numberSeed;
        numberSeed = staticTitles.Count;
    }
    public void destroyAllPond()
    {
        numberPond = 0;
        foreach (GameObject tile in listTitle)
            if (tile.GetComponent<TitleFarm>().havePond == true)
                tile.GetComponent<TitleFarm>().destroyPond();
    }
    public GameObject findTitle(int count, int index)
    {
        int Count = -1;
        if (staticTitles.Count == 0) return null;
        foreach(KeyValuePair<GameObject, GameObject> item in staticTitles)
        {
            Count = Count + 1;
            if (Count == count) return (index == 1) ? item.Key : item.Value;
        }
        return null;
    }
    public void changeStatic(GameObject title, GameObject plant, bool staticTit)
    {
        if (staticTit == true)
            if (staticTitles.TryGetValue(title, out var value) == false)
                staticTitles.Add(title, plant);
        
        if (staticTit == false)
            if (staticTitles.TryGetValue(title, out var value) == true)
                staticTitles.Remove(title);
    }

}
