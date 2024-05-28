using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public List<GameObject> monsters;
    [SerializeField] protected GameObject toAttack;

    [SerializeField] protected float atkTime = 0;
    [SerializeField] protected bool isAttack;

    protected virtual void Update()
    {
        if (this.toAttack == null) return;

        if (this.toAttack.name == "Bat") this.toAttack = null;
        else if (this.atkTime <= Time.time) this.atkTime = Time.time + this.GetComponent<DameToWarrior>().atkCoolDown;
                
        if (this.monsters.Count <= 0) this.toAttack = null; 
        if (this.toAttack != null || this.monsters.Count <= 0) return;
            
        foreach (GameObject monster in this.monsters)
        {
            if (monster == null) continue;

            Vector2 pos1 = Camera.main.ScreenToWorldPoint(transform.position);
            Vector2 pos2 = Camera.main.ScreenToWorldPoint(monster.transform.position);
            float monsterDistance = Vector2.Distance(pos1, pos2) * 100;
        }
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision == null || collision.name == "Bat" || collision.name == "Witch(Clone)" || collision.name == "Magic")
            return;
        if (collision.gameObject.layer != 10) return;
        if (collision.name == "Stone(Clone)")
        {
            collision.gameObject.GetComponent<StoneController>().ReceiveDame(dame);
            return;
        }
        collision.gameObject.GetComponent<ReceiveDame>().Damaged(dame, new Vector2(transform.position.x, transform.position.y));
    }*/
  

}
