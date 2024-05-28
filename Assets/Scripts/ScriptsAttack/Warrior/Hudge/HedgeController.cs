
using System.Collections.Generic;
using UnityEngine;

public class HedgeController : MonoBehaviour
{
    public List<GameObject> monsters1;
    public List<GameObject> monsters2;
    public List<GameObject> monsters3;
    public List<GameObject> monsters4;
    public List<GameObject> monsters5;

    public GameObject hedgeButtlets;
    public GameObject toAttack;
    private float atkCoolDown = 4f;
    private float atkTime = 0;

    public Animator animator;
    public float nearEnemyX=0;
    public float nearErrmyXFall = 0;
    public int countAtkTime = 0;

    // get buff meo
    void Start()
    {
        this.GetComponent<DameToWarrior>().dame = 50;
        this.GetComponent<DameToWarrior>().dameRecovery =50;
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (monsters1.Count >0)
        {
            foreach(GameObject monster in monsters1)
            {
                if (monster != null)
                {
                    if (toAttack == null || nearEnemyX > monster.transform.position.x)
                    {

                        toAttack = monster;
                        nearEnemyX = monster.transform.position.x;
                    }
                    if (monster.name == "Bat" && toAttack.name != "Bat")
                    {
                        if (nearEnemyX > monster.transform.position.x)
                        {
                            toAttack = monster;
                            nearEnemyX = monster.transform.position.x;
                        }
                    }
                }
            }
        }
        if (monsters2.Count > 0)
        {
            foreach (GameObject monster in monsters2)
            {
                if (monster != null)
                {
                    if (toAttack == null || nearEnemyX > monster.transform.position.x)
                    {

                        toAttack = monster;
                        nearEnemyX = monster.transform.position.x;
                    }
                    if (monster.name == "Bat" && toAttack.name != "Bat")
                    {
                        if (nearEnemyX > monster.transform.position.x)
                        {
                            toAttack = monster;
                            nearEnemyX = monster.transform.position.x;
                        }
                    }
                }
            }
        }
        if (monsters3.Count > 0)
        {
            foreach (GameObject monster in monsters3)
            {
                if (monster != null)
                {
                    if (toAttack == null || nearEnemyX > monster.transform.position.x)
                    {

                        toAttack = monster;
                        nearEnemyX = monster.transform.position.x;
                    }
                    if (monster.name == "Bat" && toAttack.name != "Bat")
                    {
                        if (nearEnemyX > monster.transform.position.x)
                        {
                            toAttack = monster;
                            nearEnemyX = monster.transform.position.x;
                        }
                    }
                }
            }
        }
        if (monsters4.Count > 0)
        {
            foreach (GameObject monster in monsters4)
            {
                if (monster != null)
                {
                    if (toAttack == null || nearEnemyX > monster.transform.position.x)
                    {

                        toAttack = monster;
                        nearEnemyX = monster.transform.position.x;
                    }
                    if (monster.name == "Bat" && toAttack.name != "Bat")
                    {
                        if (nearEnemyX > monster.transform.position.x)
                        {
                            toAttack = monster;
                            nearEnemyX = monster.transform.position.x;
                        }
                    }
                }
            }
        }
        if (monsters5.Count > 0)
        {
            foreach (GameObject monster in monsters5)
            {
                if (monster != null)
                {
                    if (toAttack == null || nearEnemyX > monster.transform.position.x)
                    {

                        toAttack = monster;
                        nearEnemyX = monster.transform.position.x;
                    }
                    if (monster.name == "Bat" && toAttack.name != "Bat")
                    {
                        if (nearEnemyX > monster.transform.position.x)
                        {
                            toAttack = monster;
                            nearEnemyX = monster.transform.position.x;
                        }
                    }
                }
            }
        }

        if (toAttack != null)
        {

            if (atkTime <= Time.time)
            {
                animator.SetBool("isAtk", true);
                atkTime = Time.time + 0.5f;
                var buttlets = Instantiate(hedgeButtlets, transform);
                buttlets.GetComponent<BulletFollow>().enemy = toAttack;
                buttlets.GetComponent<BulletFollow>().dame = this.GetComponent<DameToWarrior>().dame;
                countAtkTime++;

            }
           if(countAtkTime ==5)
            {
                animator.SetBool("isAtk", false);
                atkTime = Time.time + atkCoolDown;
                countAtkTime = 0;
            }
        }
    }
  
}
