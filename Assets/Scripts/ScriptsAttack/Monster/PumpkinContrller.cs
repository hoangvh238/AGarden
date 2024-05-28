using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PumpkinContrller : MonoBehaviour
{
    public int dame;
    public float movementSpeed = 0.002f;
    private Animator anm;
    private float attackCoolDown = 0.5f;
    private void Awake()
    {
        anm = gameObject.GetComponentInChildren<Animator>();
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals("Bullet") || collision.tag != "WarriorBoxGetDame") return;
        if (!this.GetComponent<ReceiveDame>().isEffect)
        {
            anm.SetBool("isPumpAtk", true);
            StartCoroutine(Attack(collision));
            GetComponent<ReceiveDame>().isStopped = true;
        }
    }
  
    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null || this.GetComponent<ReceiveDame>().isEffect == true)
        {
            anm.SetBool("isPumpAtk", false);
            GetComponent<ReceiveDame>().isStopped = false;
        }
        else
        {
            anm.SetBool("isPumpAtk", true);
            collision.gameObject.GetComponentInParent<DameToWarrior>().ReceiveDame(dame);
            yield return new WaitForSeconds(attackCoolDown);
            StartCoroutine(Attack(collision));
        }
    }
}