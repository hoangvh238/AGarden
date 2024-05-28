using UnityEngine;

public class BatController : MonoBehaviour
{
    private float movementSpeed = 0.01f;
    private void Update()
    {
        if (GetComponent<ReceiveDame>().isStopped && !GetComponent<ReceiveDame>().isEffect)
            transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
    }
   
}
