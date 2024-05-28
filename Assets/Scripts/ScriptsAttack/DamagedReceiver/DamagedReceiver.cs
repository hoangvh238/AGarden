using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DamagedReceiver : AutoMonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int healthMax = 1000;
    [SerializeField] protected bool isDead = false;

    [SerializeField] protected BoxCollider2D boxComponent;
    [SerializeField] protected GameObject deadFX;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
        this.LoadDeadFX();
        this.Reborn();
    }

    protected virtual void LoadDeadFX()
    {
        if (this.deadFX != null) return;
        this.deadFX = GameObject.Find("DeadFX");
        Debug.Log(transform.name + ": Load DeadFX", gameObject);
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxComponent != null) return;
        this.boxComponent = GetComponent<BoxCollider2D>();
        this.boxComponent.isTrigger = true;
        Debug.Log(transform.name + ": Load BoxCollider2D", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.CheckDead();
    }

    public virtual bool IsDead()
    {
        return this.health == 0;
    }

    public virtual void Reborn()
    {
        this.isDead = false;
        this.health = this.healthMax;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;
        this.health = Mathf.Min(this.healthMax, this.health + add);
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;
        this.health = Mathf.Max(0, this.health - deduct);
        this.CheckDead();
    }
    
    protected virtual void CheckDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        //For overright
    }
}
