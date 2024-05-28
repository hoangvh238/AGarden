using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMap : MonoBehaviour
{
    public RectTransform farmMap;
    public RectTransform attackMap;

    public GameObject farmBG;
    public GameObject attackBG;
    static int map = 1;
    public void ChangeMap()
    {
        Vector2 changeKey = new Vector2(farmMap.anchoredPosition.x, farmMap.anchoredPosition.y) ;
        farmMap.anchoredPosition = new Vector2(attackMap.anchoredPosition.x, attackMap.anchoredPosition.y);
        attackMap.anchoredPosition = changeKey;

        map = (map == 1) ? 2 : 1;
        if (map == 1)
        {
            farmBG.SetActive(true);
            attackBG.SetActive(false);
        }
        else
        {
            farmBG.SetActive(false);
            attackBG.SetActive(true);
        }
    }
}
