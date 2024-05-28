using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Stone(Clone)")
        {
            collision.gameObject.GetComponent<StoneController>().ReceiveDame(9999);
            return;
        }
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<ReceiveDame>().Damaged(9999, new Vector2(transform.position.x, transform.position.y));
        }
        else
        {
            collision.gameObject.GetComponentInParent<DameToWarrior>().ReceiveDame(999);
        }
           
    }
}
