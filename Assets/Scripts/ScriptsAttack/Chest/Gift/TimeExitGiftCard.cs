using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeExitGiftCard : MonoBehaviour
{
    float norColor = 1;
    private void Update()
    {
        // 60 * 60 time = 
        GetComponent<Image>().color = new Color(1, 1, 1, norColor-= 1f / (60*60));
        if(norColor<0.1f)
        {
            GetComponent<WarriorCardGift>().DestroyDragInstant();
             Destroy(gameObject);
        }
        }
}
