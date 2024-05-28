using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour, Ball
{
    public List<GameObject> listContact;
    public void Action()
    {
        if (true) IsNormaly();
        else IsWeakly();
    }
    public void IsNormaly()
    {
        transform.Translate(new Vector3(0.02f, 0, 0));
    }

    public void IsWeakly()
    {
        throw new System.NotImplementedException();
    }

    public void OnDestroy()
    {
        foreach (GameObject collision in listContact)
        {
            if (collision != null)
            {
                collision.gameObject.GetComponent<Animator>().speed = 1;
                collision.GetComponent<ReceiveDame>().isEffect = false;
                collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
    public GameObject Spawn(GameObject gameObject)
    {
       var spawnPoint =  GameObject.FindGameObjectWithTag("Spawner");
     foreach(Transform transform in spawnPoint.transform)
        {
            if(transform.GetComponent<SpawnPoint>().monsters.Count>0)
            {
               Instantiate(gameObject, GameObject.Find("AttackScene").transform).transform.position = new Vector2(transform.position.x-18, transform.position.y);

            }
              
        }
           
        return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CountAround" || collision.name =="Windy(Clone)"|| collision.name =="Magic") return;
        collision.gameObject.GetComponent<Animator>().speed = 0;
        if (!isExitInList(collision.gameObject))
            collision.GetComponent<ReceiveDame>().isEffect = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CountAround") return;
        collision.GetComponent<ReceiveDame>().isEffect   = false;
        collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    bool isExitInList(GameObject gameObject)
    {
        foreach (GameObject contact in listContact)
        {
            if (gameObject == contact) return true;
        }
        listContact.Add(gameObject);
        return false;
    }

    void Start()
    {
        Destroy(gameObject,15);
    }
    void Update()
    {
        Action();
    }
}
