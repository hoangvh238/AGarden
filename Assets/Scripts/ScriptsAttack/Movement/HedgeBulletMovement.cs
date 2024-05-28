using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeBulletMovement : BulletMovement
{
    [SerializeField] protected Vector3 target;
    [SerializeField] protected GameObject enemy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.speedObject = 0.005f;
        this.rightDirection = true;
    }

    public virtual void ChangeTarget(Transform enemy)
    {
        this.enemy = enemy.gameObject;
        this.target = enemy.transform.position;
    }

    protected override void FixedUpdate()
    {
        if (this.enemy == null)
        {
            Debug.Log("Can find enemy to attack -> return.");
            return;
        }

        this.LookAtTarget();
        base.FixedUpdate();
    }

    protected virtual void LookAtTarget()
    {
        this.target = this.enemy.transform.position;
        Vector3 diff = this.target - transform.parent.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    protected override void FixedMove()
    {
        base.FixedMove();

        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.target, this.speedObject);
        transform.parent.position = newPos;

      /*  transform.position += (target - transform.position).normalized * this.speedObject * Time.deltaTime;
        transform.up = (target - transform.position);*/
    }
}
