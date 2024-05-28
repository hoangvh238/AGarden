using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : AutoMonoBehaviour
{
    [SerializeField] protected Vector3 posMouse;
    public Vector3 PosMouse => this.posMouse;

    protected virtual void Update()
    {
        this.posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
