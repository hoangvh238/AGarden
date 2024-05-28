using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : Movement
{
    protected override void Move()
    {
        base.Move();
        transform.parent.position = InputController.Instance.MouseInput.PosMouse + new Vector3(0, 0, 10);
    }
}
