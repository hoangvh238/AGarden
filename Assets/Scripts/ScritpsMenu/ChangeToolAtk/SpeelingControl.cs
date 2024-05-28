using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeelingControl : MonoBehaviour
{
    bool isOpenList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpellingList()
    {
        if (!isOpenList)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            isOpenList = true;
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            isOpenList = false;
        }
    }
}
