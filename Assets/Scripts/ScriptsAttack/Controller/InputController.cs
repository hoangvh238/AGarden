using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : AutoMonoBehaviour
{
    [SerializeField] protected Mouse mouseInput;
    [SerializeField] protected static InputController instance;

    public static InputController Instance => instance;
    public Mouse MouseInput => this.mouseInput;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMouseInput();
        InputController.instance = this;
    }

    protected virtual void LoadMouseInput()
    {
        if (this.mouseInput != null) return;
        this.mouseInput = transform.Find("Mouse").GetComponent<Mouse>();
        Debug.Log(transform.name + ": Load Mouse", gameObject);
    }
}
