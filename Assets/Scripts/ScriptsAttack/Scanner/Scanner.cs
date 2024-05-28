using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Scanner : AutoMonoBehaviour
{
    [SerializeField] protected int distanceMap = 19;
    [SerializeField] protected BoxCollider2D boxScanner;
    [SerializeField] protected Rigidbody2D rigidScanner;
    [SerializeField] protected float distanceScanner = 9;
    [SerializeField] protected float speedScanner = 1;
    [SerializeField] protected bool rightDirection = true;
    [SerializeField] protected Transform enemyFound;

    public Transform EnemyFound => this.enemyFound;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxScanner();
        this.LoadRigidScanner();
    }

    protected virtual void LoadBoxScanner()
    {
        if (this.boxScanner != null) return;
        this.boxScanner = GetComponent<BoxCollider2D>();
        this.boxScanner.isTrigger = true;
        Debug.Log(transform.name + ": Load BoxCollider2D", gameObject);
    }

    protected virtual void LoadRigidScanner()
    {
        if (this.rigidScanner != null) return;
        this.rigidScanner = GetComponent<Rigidbody2D>();
        this.rigidScanner.isKinematic = true;
        Debug.Log(transform.name + ": Load RigidBody2D", gameObject);
    }

    protected virtual void OnEnable()
    {
        this.ResetScanner();
    }

    public virtual void ResetScanner()
    {
        this.gameObject.SetActive(true);
        this.enemyFound = null;
        this.boxScanner.size = Vector3.zero;
    }

    protected virtual void Update()
    {
        if (this.boxScanner.size.x >= this.distanceScanner) return;

        int key = (this.rightDirection) ? 1 : -1; 

        this.boxScanner.size = new Vector2(this.boxScanner.size.x + this.speedScanner, 1);
        this.boxScanner.offset = new Vector2((float)this.boxScanner.size.x * key / 2, this.boxScanner.offset.y);
    }
}
