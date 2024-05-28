using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBoss : MonoBehaviour
{
    public int Dame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<DameToWarrior>().ReceiveDame(Dame);
    }
}
