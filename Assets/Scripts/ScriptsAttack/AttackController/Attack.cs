using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AutoMonoBehaviour
{
    [SerializeField] protected Scanner scannerObject;
    [SerializeField] protected Animator animatorObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScanner();
        this.LoadAnimator();
    }

    protected virtual void LoadScanner()
    {
        if (this.scannerObject != null) return;
        this.scannerObject = transform.parent.Find("Scanner").GetComponent<Scanner>();
        Debug.Log(transform.name + ": Load Scanner", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animatorObject != null) return;
        this.animatorObject = transform.parent.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": Load Animator", gameObject);
    }

    protected virtual void Update()
    {
        if (this.scannerObject.EnemyFound != null && !this.scannerObject.EnemyFound.gameObject.activeSelf)
            this.scannerObject.ResetScanner();

        if (!this.CheckAttack()) this.NotAttackEnemy();
        else this.AttackEnemy();
    }

    protected virtual bool CheckAttack()
    {
        if (this.scannerObject.EnemyFound != null) return true;
        return false;
    }

    protected virtual void NotAttackEnemy()
    {
        this.animatorObject.SetTrigger("isNotAttack");
    }

    protected virtual void AttackEnemy()
    {
        this.animatorObject.SetTrigger("isAttack");
    }
}
