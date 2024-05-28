using System.Collections.Generic;
using UnityEngine;

public class Monkey : AutoMonoBehaviour
{
    public List<GameObject> monsters;
   
    private float startTime = 0;

    private Animator animator;

    private void Update()
    {

        if (monsters.Count > 0)
        {
            float distance = 1810 - this.transform.position.x;
            foreach (GameObject monster in monsters)
            {
                if (monster != null)
                {

                    float monsterDistance = Vector3.Distance(this.transform.position, monster.transform.position);
                  /*  if (monsterDistance < distance && monster.transform.position.x > this.transform.position.x && monster.GetComponent<ReceiveDame>().getGround() == true)
                    {
                        toAttack = monster;
                    }
                    else
                        toAttack = null;*/
                }

            }
        }
        ///
/*        if (toAttack != null)
        {
            if (atkTime <= Time.time)
            {
                animator.SetBool("isAttack", true);
                startTime = Time.time;
                atkTime = Time.time + atkCoolDown;
            }
        }*/

    }

}

