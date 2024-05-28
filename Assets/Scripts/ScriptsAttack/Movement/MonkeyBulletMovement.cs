using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBulletMovement : BulletMovement
{
    [SerializeField] protected float sMove = 9;
    [SerializeField] protected float rMove = 9;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.speedObject = 0.05f;
        this.rightDirection = true;
    }

    public virtual void OnEnable()
    {
        this.sMove = 9;
        this.rMove = 9;
    }

    protected override void FixedMove()
    {
        if (this.sMove > 0)
        {
            transform.parent.Translate(new Vector3(this.speedObject * this.direction, 0, 0));
            this.sMove -= this.speedObject;
        }
        else
        {
            transform.parent.Translate(new Vector3(-this.speedObject * this.direction, 0, 0));
            this.rMove -= this.speedObject;
        }

        if (this.rMove <= 0) this.DespawnToPool();
    }
}
