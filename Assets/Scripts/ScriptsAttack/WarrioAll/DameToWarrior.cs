using UnityEngine;

public class DameToWarrior : MonoBehaviour
{
    
    public GameObject dead;
    public GameObject stone;
    //
    public int Heath;
    public int dame;
    public float atkCoolDown;
    //
    public int dameRecovery;
    public float atkCoolRecovery;
    //


    public void ReceiveDame(int damaged)
    {
        Heath = Heath - damaged;
        if (Heath <= 0)
        {
            var key = Instantiate(dead);
            key.transform.position = transform.position;
            Destroy(key, 0.8f);
            this.GetComponentInParent<ObjectCell>().ChangeStatus(false);
            if (this.gameObject != null)
            {
                GameObject Ga = ManageTitleAttack.manaTitleAtta.findTit(this.gameObject);
                ManageTitleAttack.manaTitleAtta.changeStatic(Ga, this.gameObject, false);
            }
            Destroy(this.gameObject, 0.5f);
        }
        if (gameObject.tag == "Dracular")
            gameObject.GetComponent<DracularController>().Bat();
    }
    public void headStone(GameObject ghostInput)
    {
       var stoneClone =  Instantiate(stone, this.GetComponentInParent<ObjectCell>().transform);
        stoneClone.GetComponent<StoneController>().ghost = ghostInput; 
        Destroy(this.gameObject);
    }
    public void getBuff(int cateBuff, bool isActive)
    {
        if(isActive == true)
        {
            switch(cateBuff)
            {
                case 1:
                    dame += 50;
                   
                    break;
                case 2:
                    atkCoolDown =0;
                   
                    break;
                case 3:
                    Heath += 200;
                   
                    break;
            }
        }
        else
        {
            switch (cateBuff)
            {
                case 1:
                    dame = dameRecovery;
                    

                    break;
                case 2:
                    atkCoolDown = atkCoolRecovery;
                  
                    break;
            }
        }
    }
    public int getDame()
    {
        return dame;
    }
  
}
