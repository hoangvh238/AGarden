using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChestControl : MonoBehaviour
{
    public GameObject shadow;
    public GameObject dropSmoke;
    GameObject shadowClone;
 
    public void SpawnShadow(Vector2 vector2)
    {
        shadowClone = Instantiate(shadow, transform);
        shadowClone.transform.localPosition = vector2; 
    }
    public void DestroyShadow()
        {
        Destroy(shadowClone);    
        var CloneSmoke = Instantiate(dropSmoke, transform);
        Destroy(CloneSmoke, 1.15f);
        var posChest = this.GetComponentInChildren<ChestRandomMove>().gameObject.transform.position;
        CloneSmoke.transform.position = posChest;
         }
}
