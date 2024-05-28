using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    // Start is called before the first frame update
    int dame;
    void Start()
    {
        dame = 10001;
        Destroy(this.gameObject, 1.05f);
        this.GetComponentInParent<ObjectCell>().ChangeStatus(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Stone(Clone)")
        {
            collision.gameObject.GetComponent<StoneController>().ReceiveDame(dame);
            return;
        }
        
        if(collision.gameObject.GetComponent<ReceiveDame>()!=null)
        collision.gameObject.GetComponent<ReceiveDame>().Damaged(dame, new Vector2(transform.position.x, transform.position.y));
    }
}
