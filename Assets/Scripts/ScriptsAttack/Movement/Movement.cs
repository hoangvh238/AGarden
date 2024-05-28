using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : AutoMonoBehaviour
{
    [SerializeField] protected float speedObject = 2f;
    [SerializeField] protected float speedMax = 5f;
    [SerializeField] protected bool rightDirection = false;
    [SerializeField] protected bool isMovement = true;

    protected int direction;
    protected virtual void Update()
    {
        if (!this.isMovement) return;
        this.Move();
    }

    protected virtual void FixedUpdate()
    {
        if (!this.isMovement) return;
        this.FixedMove();
    }

    protected virtual void FixedMove()
    {
        if (this.rightDirection) this.direction = 1;
        else this.direction = -1;
    }

    public virtual void ResetSpeed()
    {
        //For overright
    }

    public virtual void Add(float speed)
    {
        this.speedObject = Mathf.Min(this.speedObject + speed, this.speedMax);    
    }

    protected virtual void Move()
    {
        if (this.rightDirection) this.direction = 1;
        else this.direction = -1;
        //For override
    }
}
