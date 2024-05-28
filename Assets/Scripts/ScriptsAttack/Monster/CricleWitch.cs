using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricleWitch : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void isBuff()
    {
        animator.SetBool("isBuff", true);
    }
    public void isNonBuff()
    {
        animator.SetBool("isBuff", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(10) == false || collision.name == "Witch" || collision.name == "Witch(Clone)" || collision.name != "Stone(Clone)") return;
        collision.GetComponent<ReceiveDame>().getWitchBuff();
    }
}   
