using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GiftMoney : MonoBehaviour, IPointerDownHandler
{
    public int numberMoneyGift;
    public void OnPointerDown(PointerEventData eventData)
    {

        MoneyController.Instance.AddMoney(this.numberMoneyGift);
        Destroy(this.gameObject);
        
    }

}
