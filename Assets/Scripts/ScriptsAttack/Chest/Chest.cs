using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour, IPointerDownHandler
{
    public WeightedRandomList<Transform> lootTable;

    public List<GameObject> listGif;
    public List<int> listRangeGif;

    public Transform itemHolder;
    Animator animator;
    bool isOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    { 
        
    }
    void ShowItem()
    {
        lootTable.ClearList();
        for(int i = 0; i < listGif.Count; i++)
        {
            lootTable.Add(listGif[i].transform, listRangeGif[i]);
        }
        Transform item = lootTable.GetRandom();
        Instantiate(item, itemHolder);
        itemHolder.gameObject.SetActive(true);
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
     
       
            if (this.GetComponentInParent<ChestRandomMove>().sFall <= 0)
            {

                if (isOpen == false)
                {
                    isOpen = true;
                    animator.SetBool("isOpen", true);
                    ShowItem();
                    Destroy(this.gameObject, 1);
                }

              
            }
        
    
    }
    
    
}
