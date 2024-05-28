
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlaceDrop : MonoBehaviour
{
    public GameObject objectMax;
    int maxAround;
    //
    private void Start()
    {
        maxAround = -1;
        objectMax = null;   
    }
    public void areaFindDrop(List<GameObject> list) /// only in meteor
    {
        StartCoroutine(Waiter(list, null, null));
    }
    public void areaFindDrop(List<GameObject> list, List<GameObject> list2) /// only in meteor
    {
        StartCoroutine(Waiter(list, list2, null));
    }


    public void areaFindDrop(List<GameObject> list, List<GameObject> list2, List<GameObject> list3) /// only in meteor
    {
        StartCoroutine(Waiter(list, list2, list3));
    }
      IEnumerator Waiter(List<GameObject> list, List<GameObject> list2, List<GameObject> list3)
    {
        if(list != null)StartCount(list);
        if (list2!= null) StartCount(list2);
        if (list3 != null) StartCount(list3);
        yield return new WaitForSecondsRealtime(0.01f);
        if (list2 != null) FindMax(list2);
        if (list != null) FindMax(list);
        if (list3 != null) FindMax(list3);
        ProviceTarget();
    }
    //

   


    ///
    public void FindMax(List<GameObject> list)
    {
        foreach (GameObject go in list)
        {
            var use = go.transform.GetChild(0).GetComponent<CountAround>().numberAround;
            if (use > maxAround)
            {
                maxAround = go.transform.GetChild(0).GetComponent<CountAround>().numberAround;
                objectMax = go.gameObject;
            }
            go.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    ///
    public void StartCount(List<GameObject> list)
    {
        foreach (GameObject go in list)
        {
            go.transform.GetChild(0).gameObject.SetActive(true);

        }
    }

    public void ProviceTarget()
    {
        Vector2 vector2 = objectMax.transform.position;
        GetComponentInParent<Fire>().target = vector2;
    }
  
}
