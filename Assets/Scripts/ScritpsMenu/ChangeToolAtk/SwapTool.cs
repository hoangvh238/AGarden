using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTool : MonoBehaviour
{
    bool isSpell;
    
   public void SetTool()
    {
        if(isSpell==false)
        {
            this.transform.parent.GetChild(0).gameObject.SetActive(false);
            this.transform.parent.GetChild(1).gameObject.SetActive(true);
            isSpell=true;

        }
        else
        {
            this.transform.parent.GetChild(1).gameObject.SetActive(false);
            this.transform.parent.GetChild(0).gameObject.SetActive(true);
          isSpell =false;
        }
    }
}
