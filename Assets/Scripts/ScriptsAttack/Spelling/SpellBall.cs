using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBall : MonoBehaviour
{
    [SerializeField]
    private GameObject speel;

    [SerializeField]
    private List<GameObject> historySpawn;

    // Start is called before the first frame update
  

    // Update is called once per frame
    void FixedUpdate()
    {
        StatusSpell();

    }
    protected virtual void StatusSpell()
    {
     
    }
    private void Start()
    {
        SpawnEffect();
  
    }

    public void SpawnEffect()
    {
        
       // if (this.gameObject.name == null) return;
        if(this.name =="FireBall(Clone)")
        {
            Fire fire = new Fire();
            fire.Spawn(speel);
        }
        if(this.name == "WindBall(Clone)")
        {
            Wind wind = new Wind();
            wind.Spawn(speel);
        }
        if(this.name == "IceBall(Clone)")
        {
            Ice ice = new Ice();    
            ice.Spawn(speel);
        }
       
    }
}
