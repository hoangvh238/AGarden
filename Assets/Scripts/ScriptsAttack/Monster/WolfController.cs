/*using System.Collections;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public int dame;
    public float movementSpeed = 0.01f;
    private Animator anm;
    private float attackCoolDown;
    private void Start()
    {
        dame = 100;
        attackCoolDown = 0.5f;
        anm = gameObject.GetComponentInChildren<Animator>();
       // anm.SetBool("isSkeDead", false);
    }
    private void Update()
    {
        if (!GetComponent<ReceiveDame>().isStopped && !GetComponent<ReceiveDame>().isEffect)
            transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals("Bullet") || collision.tag != "WarriorBoxGetDame") return;
        if (!this.GetComponent<ReceiveDame>().isEffect)
        {
            anm.SetBool("isWolfAtk", true);
            StartCoroutine(Attack(collision));
            GetComponent<ReceiveDame>().isStopped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anm.SetBool("isWolfAtk", false);
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null || this.GetComponent<ReceiveDame>().isEffect == true)
        {
            anm.SetBool("isWolfAtk", false);
            GetComponent<ReceiveDame>().isStopped = false;
        }
        else
        {
            anm.SetBool("isWolfAtk", true);
            collision.gameObject.GetComponentInParent<DameToWarrior>().ReceiveDame(dame);
            yield return new WaitForSeconds(attackCoolDown);
            StartCoroutine(Attack(collision));
        }
    }
}
*/