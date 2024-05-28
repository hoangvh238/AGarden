using System.Collections;
using UnityEngine;

public class DracularController : MonoBehaviour
{
    public GameObject smoke;
    public float minHeath;
    public int dame;
    public float movementSpeed;
    private Animator anm;
    private float attackCoolDown;
    public bool isStopped;
    private bool isBat;
    public ReceiveDame key;

    private void Start()
    {
        key = GetComponent<ReceiveDame>();
        minHeath = key.health / 2;
        dame = 20;
        attackCoolDown = 0.5f;
        anm = GetComponent<Animator>();
    }

    private void Update()
    {
        Bat();
        if (!key.isStopped && !key.isEffect)
            transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals("Bullet") || collision.tag !="WarriorBoxGetDame") return;
        anm.SetBool("isDracularAtk", true);
        StartCoroutine(Attack(collision));
        if(!isBat) key.isStopped = true;
    }
 
    public void Bat()
    {
        if (key.health <= minHeath && key.health > 0)
        {
            if(isBat == false)
            {
                key.isStopped = true;
                GameObject deadAnm = Instantiate(smoke, transform);
                Destroy(deadAnm, 0.5f);
            }

            key.isStopped = false;
            isBat = true;
    
            this.name = "Bat";
            anm.SetBool("isBat", true);

            this.GetComponent<DracularController>().enabled = false;
            this.GetComponent<BatController>().enabled = true;
        }
    }

    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null || this.GetComponent<ReceiveDame>().isEffect == true)
        {
            anm.SetBool("isDracularAtk", false);
            key.isStopped = false;
        }
        else
        {
            anm.SetBool("isDracularAtk", true);
            if (isBat == false)
            collision.gameObject.GetComponentInParent<DameToWarrior>().ReceiveDame(dame);
         
            yield return new WaitForSeconds(attackCoolDown);
            StartCoroutine(Attack(collision));
        }
    }
}
