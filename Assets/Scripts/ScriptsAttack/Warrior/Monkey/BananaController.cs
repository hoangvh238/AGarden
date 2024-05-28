using UnityEngine;

public class BananaController : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float sMove;
    [SerializeField] protected float rMove;

    [SerializeField] protected int dame = 100;
    [SerializeField] protected int healthBanana = 6;
    [SerializeField] protected bool isGoback = false;

    [SerializeField] protected GameObject banana;
    [SerializeField] protected GameObject bananaBreakingEffect;

    private void Start()
    {
        this.sMove = 9 - this.banana.transform.position.x;
        this.rMove = this.sMove;
    }

    private void Update()
    {
        switch (this.healthBanana)
        {
            case 0:
                Destroy(this.gameObject);
                break;
            case 1:
                dame = 10;
                break;
            case 2:
                dame = 20;
                break;
            case 3:
                dame = 30;
                break;
            case 4:
                dame = 50;
                break;
            case 5:
                dame = 70;
                break;
        }

        if (sMove > 0)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            sMove -= speed;
        }
        else
        {
            transform.Translate(new Vector3(speed * -1, 0, 0));
            rMove -= speed;
        }

        if (rMove <= 0) Destroy(banana);
    }

    [System.Obsolete]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null || collision.name == "Bat"|| collision.name == "Witch(Clone)" || collision.name == "Magic")
        return;
        if (collision.gameObject.layer != 10) return;
            healthBanana -= 1;

        if (collision.name == "Stone(Clone)")
        {
            collision.gameObject.GetComponent<StoneController>().ReceiveDame(dame);
            return;
        }
          
        collision.gameObject.GetComponent<ReceiveDame>().Damaged(dame, new Vector2(transform.position.x, transform.position.y));
        var effect = Instantiate(bananaBreakingEffect, transform);
        Color red = Color.yellow;
        effect.GetComponent<ChangeColorPar>().SetEffect(red);
        Destroy(effect, 0.5f);
           
    }
    

}
