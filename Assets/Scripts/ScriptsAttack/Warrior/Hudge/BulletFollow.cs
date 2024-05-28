using Unity.VisualScripting;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    public GameObject enemy;
    public int dame;
   
   /* void Update()
    {
        if (enemy != null) target = rectEne.position;

        transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
        transform.up = (target - transform.position);

        *//*
        if (enemy != null) transform.position += Vector3.right * speed * Time.deltaTime;
        else transform.position += (transform.localRotation * Vector3.up).normalized * speed * Time.deltaTime;*//*
    }*/
   /* public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Stone(Clone)")
        { 
            collision.gameObject.GetComponent<StoneController>().ReceiveDame(dame);
            Destroy(this.gameObject);
        }   
        else
        {
            collision.gameObject.GetComponent<ReceiveDame>().Damaged(dame, new Vector2(transform.position.x, transform.position.y));
            Destroy(this.gameObject);
        }
         

    }*/
}
