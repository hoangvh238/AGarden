using UnityEngine;

public class CountAround : MonoBehaviour
{
    public int numberAround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) numberAround++;
    }
}
