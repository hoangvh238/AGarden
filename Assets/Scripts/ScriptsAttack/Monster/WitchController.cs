using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WitchController : AutoMonoBehaviour
{
    [SerializeField] protected float movementSpeed = 0.005f;
    [SerializeField] protected float sMove;
    [SerializeField] protected float sMoveBuff;

    [SerializeField] protected Light2D lightWitch;
    [SerializeField] protected SpriteRenderer sprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpriteRenderer();
        this.LoadLight();
        this.LoadSMove();
    }

    protected virtual void LoadSpriteRenderer()
    {
        if (this.sprite != null) return;
        this.sprite = GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": Load Sprite", gameObject);
    }

    protected virtual void LoadLight()
    {
        if (this.lightWitch != null) return;
        this.lightWitch = GetComponent<Light2D>();
        Debug.Log(transform.name + ": Load Light2D", gameObject);
    }

    protected virtual void LoadSMove()
    {
        this.sMove = 3f;
        this.sMoveBuff = -this.sMove / 2;
    }

    protected virtual void Update()
    {
        this.CheckBuff();
    }

    protected virtual void CheckBuff()
    {
        if (!GetComponent<ReceiveDame>().isStopped && !GetComponent<ReceiveDame>().isEffect)
        {
            if (this.sMove > 0) { this.sMove = this.sMove - this.movementSpeed; return; }

            this.OnBuff();

            if (this.sMove > this.sMoveBuff) { this.sMove -= this.movementSpeed; return; }

            this.OffBuff();
            this.LoadSMove();
        }
    }

    protected virtual void OnBuff()
    {
        this.sprite.color = new Color(0.98f, 0.185f, 1, 1);

        /*GetComponentInChildren<CricleWitch>().isBuff();*/

        this.lightWitch.enabled = true;
    }

    protected virtual void OffBuff()    
    {
        this.sprite.color = new Color(1, 1, 1, 1);

/*        GetComponentInChildren<CricleWitch>().isNonBuff();*/

        this.lightWitch.enabled = false;
    }
}
