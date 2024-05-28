using UnityEngine;

public class GhostController : AutoMonoBehaviour
{
    [SerializeField] protected float movementSpeed = 0.01f;
    [SerializeField] protected float sMove = 6;
    [SerializeField] protected float sMoveProtect;

    [SerializeField] protected bool isProtect;
    [SerializeField] protected bool isStopped = false;
    [SerializeField] protected bool isDead;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIndex();
    }

    protected virtual void LoadIndex()
    {
        this.sMove = 6;
        this.sMoveProtect = -this.sMove / 2;
    }

    private void Update()
    {
        if (isDead == true || GetComponent<ReceiveDame>().isStopped) return;

        if (GetComponent<ReceiveDame>().isEffect) return;

        transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
        if (sMove > 0) { sMove -= movementSpeed; return; }
        
        GetComponent<ReceiveDame>().isGround = false;
        isProtect = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.57f);

        if (sMove > sMoveProtect) sMove -= movementSpeed;
        else
        {
            GetComponent<ReceiveDame>().isGround = true;
            isProtect = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isProtect == true) return;

        if (this.GetComponent<ReceiveDame>().isEffect == true) return;

        collision.gameObject.GetComponentInParent<DameToWarrior>().headStone(this.gameObject);
        isDead = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        this.gameObject.SetActive(false);
    }
    
}

