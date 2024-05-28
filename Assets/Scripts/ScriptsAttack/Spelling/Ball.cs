using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface Ball 
{
    public abstract GameObject Spawn(GameObject gameObject);
    public  void Action();
    public  void IsWeakly();
    public  void IsNormaly();
    public  void OnDestroy();
  

}
