using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventorySpell : MonoBehaviour
{
    public TMP_Text fire; //0
    public TMP_Text ice;  //1
    public TMP_Text thunder; //2
    public TMP_Text wind; //3
  
    public List<int> spells = new List<int>();
    public List<GameObject> spellsPrefab = new List<GameObject>();  
    void Start()
    {
        for (int i = 0; i<4;i++)
        {
            spells[i] = 5;
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(this.isActiveAndEnabled)
        {
            fire.text = "" + spells[0];
            ice.text = "" + spells[1];
            thunder.text = "" + spells[2];
            wind.text = "" + spells[3];
        }
    }
    public void useSpell(int cate)
    {
        if(spells[cate] >0)
        {
            if(this.transform.parent.childCount ==2)
            {
                Destroy(this.transform.parent.GetChild(1).gameObject);
            }
            Instantiate(spellsPrefab[cate], transform.parent);
            spells[cate] -= 1;
        }
    }
}
