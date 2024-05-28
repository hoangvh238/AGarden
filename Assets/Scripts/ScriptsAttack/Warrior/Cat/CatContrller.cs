
using System.Collections.Generic;
using UnityEngine;

public class CatContrller : MonoBehaviour
{
    public GameObject gameManager;
    public Animator animator;
    public int heath;
    public bool isSleep;    
    //
    public float timeCycle;
    public float buffTime;
    public float sleepTime;
    //
    public List<GameObject> listBuffSent;
    //
    public int dame;

    //
    public float timeStartBuff=0;
    //
    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        animator.SetBool("isBuff", true);
        timeCycle = 6;
        buffTime = 0;
        sleepTime = 3;
    }
    private void Update()
    {
     
        if(isSleep)
        {
           listBuffSent.Clear();
        }
            if (buffTime <= Time.time)
            {
            timeStartBuff = Time.time;
   
            isSleep = false;
            animator.SetBool("isBuff", true);
                buffTime = Time.time + timeCycle;
                
            }
            else
            {
            

            if (buffTime <= Time.time + sleepTime) //time buff = 
                {
                
                    isSleep = true;
                    animator.SetBool("isBuff", false);
                }


            }
        }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WarriorBoxGetDame")
        {
            if ((collision.GetComponentInParent<DameToWarrior>().gameObject.name == "DogGame(Clone)") || (collision.GetComponentInParent<DameToWarrior>().gameObject.name == "MonkeyGame(Clone)") || (collision.GetComponentInParent<DameToWarrior>().gameObject.name == "HedgeGame(Clone)") || (collision.GetComponentInParent<DameToWarrior>().gameObject.name == "TurtleGame(Clone)"))
            {
                if (collision.GetComponentInParent<ControllListBuff>().listCatBuff.Count == 0)
                {
                  
                    var buff = collision.GetComponentInParent<ControllListBuff>().effectBuff;
                    buff.GetComponent<CatBuff>().timeExit = timeCycle - sleepTime- ( Time.time - timeStartBuff);                
                    listBuffSent.Add(buff);
                    collision.GetComponentInParent<ControllListBuff>().listCatBuff.Add(Instantiate(buff, collision.gameObject.transform.parent));

                }
                else
                {
                    // buff----deBuff = time put warrior - time cat start buff + time from put warrior to end buff =>>> time from put warrior to end buff = ... 
                    collision.transform.parent.GetComponentInChildren<CatBuff>().timeExit= timeCycle - sleepTime;
                }
            }
        }
    }
    


}
