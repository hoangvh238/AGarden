using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    public int heal = 450;
    public Animator animator;
    public GameObject ghost;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReceiveDame(int damaged)
    {
        if (heal - damaged <= 0)
        {
            this.GetComponentInParent<ObjectCell>().ChangeStatus(false);
            ghost.GetComponent<ReceiveDame>().Damaged(1000,new Vector2(transform.position.x, transform.position.y));
            Destroy(this.gameObject);
          
        }
        else
        {
            if (heal < 400)
                animator.SetInteger("isBreak", 1);
            if(heal<300)
                animator.SetInteger("isBreak", 2);
            if(heal<200)
                animator.SetInteger("isBreak", 3);
            if(heal<100)
                animator.SetInteger("isBreak", 4);
            heal -= damaged;
        }
    }

}
