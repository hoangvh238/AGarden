using System.Collections;
using UnityEngine;

public class SkeletonController : AutoMonoBehaviour
{
    /*[SerializeField] protected int dame = 2;
    [SerializeField] protected Animator animator;
    [SerializeField] float attackCoolDown = 0.5f;*/


  /*  public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.GetComponent<ReceiveDame>().isEffect)
        {
            this.animator.SetBool("isZomAtk", true);
            StartCoroutine(Attack(collision));
          *//*  GetComponent<ReceiveDame>().isStopped = true;*//*
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null || this.GetComponent<ReceiveDame>().isEffect == true) 
        {
            this.animator.SetBool("isZomAtk", false);
           *//* GetComponent<ReceiveDame>().isStopped = false;*//*
        }
        else
        {
            this.animator.SetBool("isZomAtk", true);
            collision.gameObject.GetComponentInParent<DameToWarrior>().ReceiveDame(dame);
            yield return new WaitForSeconds(attackCoolDown);
            StartCoroutine(Attack(collision));
        }
    }*/
}
