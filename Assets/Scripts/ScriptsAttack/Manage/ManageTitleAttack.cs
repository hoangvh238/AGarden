using System.Collections.Generic;
using UnityEngine;

public class ManageTitleAttack : MonoBehaviour
{
    public int numberBall = 0;
    public static Dictionary<GameObject, GameObject> listWarrior;
    public static ManageTitleAttack manaTitleAtta;

    void Awake()
    {
        listWarrior = new Dictionary<GameObject, GameObject>();
        manaTitleAtta = this;
    }
    public Vector2 findMaxPos()
    {
        Vector2 target = new Vector2(-600, 0);
        foreach(KeyValuePair<GameObject, GameObject> warrior in listWarrior)
        {
            Vector2 pos = warrior.Key.GetComponent<RectTransform>().localPosition;
            if (pos.x > target.x) target = pos;
        }
        return target;
    }
    public GameObject randTitle()
    {
        if (listWarrior.Count - numberBall <= 0) return null;

        int key = Random.Range(0, listWarrior.Count);
        while (findTitle(key, 1).GetComponent<ObjectCell>().haveBall == true)
            key = Random.Range(0, listWarrior.Count);

        numberBall = numberBall + 1;
        return findTitle(key, 1);
    }
    public GameObject findTit(GameObject warrior)
    {
        foreach (KeyValuePair<GameObject, GameObject> item in listWarrior)
            if (item.Value == warrior) return item.Key;
        return null;
    }
    public GameObject findWariror(GameObject title)
    {
        foreach (KeyValuePair<GameObject, GameObject> item in listWarrior)
            if (item.Key == title) return item.Value;
        return null;
    }
    public GameObject findTitle(int count, int index)
    {
        int Count = -1;
        if (listWarrior.Count == 0) return null;
        foreach(KeyValuePair<GameObject, GameObject> item in listWarrior)
        {
            Count = Count + 1;
            if (Count == count) return (index == 1) ? item.Key : item.Value;
        }
        return null;
    }
    public void changeStatic(GameObject title, GameObject warrior, bool staticTit)
    {
        if (staticTit == true)
            if (listWarrior.TryGetValue(title, out var value) == false)
                listWarrior.Add(title, warrior);
        if (staticTit == false)
            // bug quai 
            try
            {
                if (listWarrior.TryGetValue(title, out var value) == true)
                    listWarrior.Remove(title);
            }
            catch
            {
                return;
            }
           //
    }

}
