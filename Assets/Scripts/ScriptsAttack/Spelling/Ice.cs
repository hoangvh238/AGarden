using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour,Ball
{
    public  List<GameObject> monsterIce;
    public Collider2D collider2D;
    public Vector2 maxPos;
    public void Action()
    {
        //
    }

    public void IsNormaly()
    {
        //
    }

    public void IsWeakly()
    {
        //
    }

    public void OnDestroy()
    {
        foreach (GameObject collision in monsterIce)
        {
            if (collision != null)  
            {
                collision.gameObject.GetComponent<Animator>().speed = 1;
                collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                collision.GetComponent<ReceiveDame>().isEffect = false;
            }
        }
    }
    public GameObject Spawn(GameObject gameObject)
    {
        return Instantiate(gameObject, GameObject.Find("AttackScene").transform);
    }


    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        maxPos = new Vector2(20, 20);
        Destroy(this.gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
      
        if ((Vector2)collider2D.bounds.size == maxPos)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CountAround" || collision.name == "Windy(Clone)" || collision.name == "Magic") return;
        collision.gameObject.GetComponent<Animator>().speed = 0;
        monsterIce.Add(collision.gameObject);
        collision.GetComponent<SpriteRenderer>().color = new Color(0.1960784f, 3137255f, 1, 1);
        collision.GetComponent<ReceiveDame>().isEffect = true;

    }
}
