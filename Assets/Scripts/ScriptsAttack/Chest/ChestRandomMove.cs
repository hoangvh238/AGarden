using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRandomMove : MonoBehaviour
{
    // y position 600 / x->0->700 /miny =300 max y =-435 // x la positon spawn // y la quang duong di chuyen
    public int sFall;
    RectTransform rt;
    Animator animator;
    public GameObject shadow;
    bool isSetSpeed;
    bool doOnlyOne;
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        int rantFixed = Random.Range(0, 700);
        rt.transform.localPosition = new Vector2(rantFixed,600);
        int rant = Random.Range(-435, 300);
        sFall = rant>0?600-rant:600+(-1*rant);
        animator = GetComponentInChildren <Animator>();
        animator.speed = 0;
        this.GetComponentInParent<ShadowChestControl>().SpawnShadow(new Vector2(rantFixed, rant-10));

    }
    // Update is called once per frame
    void Update()
    {
        
        if (sFall > 0)
        {
            this.transform.localPosition += new Vector3(0, -2, 0);
            sFall -= 2;
        }
        else
            if (isSetSpeed == false)
        {
            animator.speed = 1;
          
            if (!doOnlyOne)
            {
                this.GetComponentInParent<ShadowChestControl>().DestroyShadow();
                doOnlyOne = true;
            }
              
        
            isSetSpeed = true;
        }
           

    }
}
